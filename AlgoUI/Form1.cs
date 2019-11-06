﻿using Algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private IPathSearch alg;
        Brush yBrush = Brushes.Yellow;
        Brush sBrush = Brushes.SkyBlue;
        Control canvas;
        public Form1()
        {
            InitializeComponent();
            canvas = pictureBox1;
            loadMap("simple.png");
            startBtn_Click(null, null);
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadMap(openFileDialog1.FileName);
            }
        }

        private void loadMap(String filename)
        {
            bmp = new Bitmap(Image.FromFile(filename));
            updateView();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            draw(e);
        }

        private void draw(PaintEventArgs e)
        {
            if (bmp != null)
            {
                if (alg != null)
                {
                    //var watch = System.Diagnostics.Stopwatch.StartNew();
                    var scale = Math.Min((float)canvas.Width / bmp.Width, (float)canvas.Height / bmp.Height);

                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    e.Graphics.ScaleTransform(scale, scale);
                    //e.Graphics.DrawImage(bmp, 0, 0);
                    for (int x = 0; x < alg.pathFlagsMap.width; x++)
                    {
                        for (int y = 0; y < alg.pathFlagsMap.height; y++)
                        {
                            var v = alg.pathFlagsMap[x, y];
                            Brush brush;
                            if (v.HasFlag(CellFlags.VISITED) && !v.HasFlag(CellFlags.START) && !v.HasFlag(CellFlags.END))
                            {
                                if (v.HasFlag(CellFlags.FRONTIER))
                                {
                                    brush = yBrush;
                                }
                                else
                                {
                                    brush = getBrush(Color.FromArgb(255,0,0,Math.Max(255 - alg.distMap[x,y]*3, 0)));
                                }
                                e.Graphics.FillRectangle(brush, x, y, 1, 1);
                            }
                            else
                            {
                                brush = getBrush(bmp.GetPixel(x, y));
                                e.Graphics.FillRectangle(brush, x, y, 1, 1);
                            }
                        }
                    }
                    //watch.Stop();
                    //var elapsedMs = watch.ElapsedMilliseconds;
                    //System.Diagnostics.Debug.WriteLine("redraw took: {0}", elapsedMs);
                }
            }
        }

        Dictionary<Color, Brush> brushCache = new Dictionary<Color, Brush>();
        private int iterN;
        private decimal stopAtIter;
        private int delay;
        private bool stop;
        private Thread worker;

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

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void runSingleIter_Click(object sender, EventArgs e)
        {
            runSingleIterInternal();
            updateView();
        }

        private void updateView()
        {
            updateAlgoStatus();
            canvas.Invalidate();
        }

        private void runSingleIterInternal()
        {
            //string startTime = DateTime.Now.ToString("hh.mm.ss.fff");
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            if (alg != null && !alg.status.HasFlag(IterStatus.FINISHED))
            {
                iterN++;
                alg.iter();
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
                statusLbl.Text = alg.status.ToString();
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
                SearchContext ctx = new SearchContext(map, startCell, destCell);
                alg = new AStarSearch(ctx);
                iterN = 0;
                updateView();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            draw(e);
        }

        private void runNItersBtn_Click(object sender, EventArgs e)
        {
            stopAtIter = iterN + maxIters.Value;
            //iterTimer.Enabled = true;
            runThread();
        }

        private void runThread()
        {
            while (worker != null)
            {
                stop = true;
                worker.Join();
            }
            worker = new Thread(runContinuously);
            worker.Start();
        }

        private void runContinuously()
        {
            stop = false;
            while (iterN < stopAtIter && !stop)
            {
                runSingleIterInternal();
                this.Invoke((Action)(() =>
                {
                    if (iterN % redrawFreq.Value == 0)
                    {
                        updateView();
                    }
                }));
                Thread.Sleep(delay);
            }

            this.Invoke((Action)updateView);
            worker = null;
        }

        private void iterTimer_Tick(object sender, EventArgs e)
        {
            if (iterN == stopAtIter)
            {
                iterTimer.Enabled = false;
                return;
            }
            runSingleIterInternal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iterTimer.Enabled = false;
            stop = true;
        }

        private void delaySlider_ValueChanged(object sender, EventArgs e)
        {
            //iterTimer.Interval = delaySlider.Value;
            delay = delaySlider.Value;
        }
    }
}
