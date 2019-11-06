using Algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = Algo.Point;

namespace AlgoUI
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Map map;
        private FloodSearch alg;

        public Form1()
        {
            InitializeComponent();
            loadMap("C:/Users/gamer/source/repos/Algo/AlgoUI/simple.png");
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

            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (bmp != null)
            {
                var scale = Math.Min((float)panel2.Width / bmp.Width, (float)panel2.Height / bmp.Height);
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                e.Graphics.ScaleTransform(scale, scale);
                e.Graphics.DrawImage(bmp, new System.Drawing.Point(0, 0));
            }
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }

        private void runSingleIter_Click(object sender, EventArgs e)
        {
            if (alg != null)
            {
                alg.iter();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                map = new Map(bmp.Width, bmp.Height);
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
                alg = new FloodSearch(ctx);
            }
        }
    }
}
