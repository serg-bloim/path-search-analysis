using Algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = Algo.Point;

namespace AlgoUI
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Map<Cell> map;
        private SearchContext ctx;
        private IPathSearch alg;
        Brush yBrush = Brushes.Yellow;
        Brush sBrush = Brushes.SkyBlue;

        Dictionary<Color, Brush> brushCache = new Dictionary<Color, Brush>();
        private int iterN;
        private decimal stopAtIter;
        private int delay;
        private bool stop;
        private Thread worker;
        private TimeSpan totalTime;

        public Form1()
        {
            InitializeComponent();
            algoDDBox.SelectedItem = algoDDBox.Items[0];
            initAlgos();
            loadMap("simple.png");
            startBtn_Click(null, null);
            delayLbl.Text = "Iteration delay: " + delaySlider.Value + "ms";
            renderFreqLbl.Text = "Render every iterations: " + redrawFreq.Value;
        }

        private void initAlgos()
        {
            SortedDictionary<string, Type> algos = new SortedDictionary<string, Type>();
            var allAssemblies = new List<Assembly>();
            var staticAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            allAssemblies.AddRange(staticAssemblies);
            foreach (string dll in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));
            foreach (var assembly in allAssemblies)
            {
                foreach (var t in assembly.GetTypes())
                {
                    if (t.IsAbstract || t.IsInterface)
                    {
                        continue;
                    }
                    if (t.GetInterfaces().Contains(typeof(IPathSearch)))
                    {
                        IPathSearch obj = (IPathSearch)Activator.CreateInstance(t);
                        algos.Add(obj.name, t);
                    }
                }
            }
            algoDDBox.DataSource = algos.ToList();
            algoDDBox.DisplayMember = "Key";
            algoDDBox.ValueMember = "Value";
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadMap(openFileDialog1.FileName);
                startBtn.PerformClick();
            }
        }

        private void loadMap(String filename)
        {
            bmp = new Bitmap(Image.FromFile(filename));
            updateView();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void draw(PaintEventArgs e)
        {
            if (bmp != null)
            {
                if (alg != null)
                {
                    //var watch = System.Diagnostics.Stopwatch.StartNew();
                    var scale = Math.Min((float)pictureBox1.Width / bmp.Width, (float)pictureBox1.Height / bmp.Height);

                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    e.Graphics.ScaleTransform(scale, scale);
                    e.Graphics.DrawImage(bmp, 0, 0);
                    foreach (Point p in alg.getVisitedPoints())
                    {
                        drawPixel(e.Graphics, p, sBrush);
                    }
                    foreach (Point p in alg.getFrontierPoints())
                    {
                        drawPixel(e.Graphics, p, yBrush);
                    }
                    drawPixel(e.Graphics, ctx.startCell, Brushes.Red);
                    drawPixel(e.Graphics, ctx.dstCell, Brushes.Green);
                }
            }
        }

        private void drawPixel(Graphics g, Point p, Brush b)
        {
            g.FillRectangle(b, p.x - 0.5f, p.y - 0.5f, 1, 1);
        }

        private Brush getBrush(Color color)
        {
            if (brushCache.ContainsKey(color))
            {
                return brushCache[color];
            }
            else
            {
                SolidBrush solidBrush = new SolidBrush(color);
                brushCache[color] = solidBrush;
                return solidBrush;
            }
        }

        private void runSingleIter_Click(object sender, EventArgs e)
        {
            runSingleIterInternal();
            updateView();
        }

        private void updateView()
        {
            updateAlgoStatus();
            pictureBox1.Invalidate();
        }

        private void runSingleIterInternal()
        {
            //string startTime = DateTime.Now.ToString("hh.mm.ss.fff");
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            if (alg != null && !alg.status.HasFlag(IterStatus.FINISHED))
            {
                alg.runIter();
                iterN = alg.getIterNum();
            }
            else
            {
                stop = true;
            }

            // the code that you want to measure comes here
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //System.Diagnostics.Debug.WriteLine("{0} iter, took: {1}", startTime, elapsedMs);
        }

        private void updateAlgoStatus()
        {
            if (alg != null)
            {
                statusLbl.Text = $"{alg.getIterNum()} : {alg.status.ToString()}\nTotal time: {totalTime.Milliseconds}";
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                map = new Map<Cell>(bmp.Width, bmp.Height);
                Point startCell = new Point();
                Point destCell = new Point();
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Cell v = Cell.fromInt(bmp.GetPixel(x, y).ToArgb());
                        if (v.isStart)
                        {
                            startCell.x = x;
                            startCell.y = y;
                            v = Cell.FREE;
                        }
                        if (v.isDest)
                        {
                            destCell.x = x;
                            destCell.y = y;
                            v = Cell.FREE;
                        }
                        map[x, y] = v;
                    }
                }
                craeteAlgo(map, startCell, destCell);
                iterN = 0;
                updateView();
            }
        }

        private void craeteAlgo(Map<Cell> map, Point startCell, Point destCell)
        {
            ctx = new SearchContext(map, startCell, destCell);
            var type = (Type)algoDDBox.SelectedValue;
            if (type != null)
            {
                alg = (IPathSearch)Activator.CreateInstance(type);
                alg.init(ctx);
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            draw(e);
        }

        private void runNItersBtn_Click(object sender, EventArgs e)
        {
            stopAtIter = iterN + maxIters.Value;
            runThread();
        }

        private void runThread()
        {
            while (worker != null)
            {
                stop = true;
                worker.Join();
            }
            worker = new Thread(() => runContinuously());
            worker.Start();
        }

        private void runContinuously(bool nonStop = false)
        {
            stop = false;
            while (iterN < stopAtIter && !stop)
            {
                runSingleIterInternal();
                if (!nonStop)
                {
                    this.Invoke((Action)(() =>
                    {
                        if (iterN % redrawFreq.Value == 0)
                        {
                            updateView();
                        }
                    }));
                    Thread.Sleep(delay);
                }
            }

            this.Invoke((Action)updateView);
            worker = null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void delaySlider_ValueChanged(object sender, EventArgs e)
        {
            delay = delaySlider.Value;
            delayLbl.Text = "Iteration delay: " + delaySlider.Value + "ms";
        }

        private void algoDDBox_SelectedValueChanged(object sender, EventArgs e)
        {
            startBtn.PerformClick();
        }

        private void redrawFreq_ValueChanged(object sender, EventArgs e)
        {
            renderFreqLbl.Text = "Render every iterations: " + redrawFreq.Value;
        }

        private void runTillEndBtn_Click(object sender, EventArgs e)
        {
            stopAtIter = 999999;
            if (backgroundCB.Checked)
            {
                runThread();
            }
            else
            {
                runInSameThread();
                updateAlgoStatus();
                pictureBox1.Invalidate();
            }
        }

        private void runInSameThread()
        {
            IterStatus stat = IterStatus.NONE;
            int i = 0;
            Stopwatch sw = Stopwatch.StartNew();
            while (!stat.HasFlag(IterStatus.FINISHED))
            {
                if (i++ >= 9999)
                {
                    break;
                }
                stat = alg.runIter();
            }
            totalTime = sw.Elapsed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
