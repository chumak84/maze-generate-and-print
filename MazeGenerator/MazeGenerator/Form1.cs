using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        PrintDocument printDoc = new PrintDocument();
        PrinterSettings _printerSettings;

        Stopwatch watch = new Stopwatch();

        const int DEFAULT_MAZE_WIDTH = 70;
        const int DEFAULT_MAZE_HEIGHT = 100;

        Maze _maze;

        public Form1()
        {
            InitializeComponent();
            printDoc.PrintPage += PrintDoc_PrintPage;
            nbXCount.Value = DEFAULT_MAZE_WIDTH;
            nbYCount.Value = DEFAULT_MAZE_HEIGHT;
            btnPrint.Enabled = false;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var rf = e.PageSettings.PrintableArea;
            var g = e.Graphics;

            watch.Start();

            int mXCount = _maze.XComponentCount;
            int mYCount = _maze.YComponentCount;
            var connections = _maze.Connections;

            float width = rf.Width;
            float height = rf.Height;
            float colWidth = width / mXCount;
            float colHeight = height / mYCount;

            float x1 = 0;
            //float x2 = colWidth;
            float y1 = 0;
            //float y2 = colHeight;

            Pen p = Pens.Black;
            int element = 0;
            int lest = mXCount * mYCount - 1;
            for(int iY = 0; iY < mYCount; iY++)
            {
                x1 = 0;
                for(int iX = 0; iX < mXCount; iX++)
                {
                    if (element != 0 && !connections[element].Contains(element - mXCount))
                        DrawTop(g, colWidth, x1, y1, p);
                    if(!connections[element].Contains(element - 1))
                        DrawLeft(g, colHeight, x1, y1, p);
                    if (!connections[element].Contains(element + 1))
                        DrawRight(g, colWidth, colHeight, x1, y1, p);
                    if(element != lest && !connections[element].Contains(element + mXCount))
                        DrawBottom(g, colWidth, colHeight, x1, y1, p);
                    element++;
                    x1 += colWidth;
                }
                y1 += colHeight;
            }
            watch.Stop();
            lblPrintTime.Text = watch.ElapsedMilliseconds.ToString();
            watch.Reset();
        }

        private static void DrawBottom(Graphics g, float colWidth, float colHeight, float x1, float y1, Pen p)
        {
            g.DrawLine(p, x1, y1 + colHeight, x1 + colWidth, y1 + colHeight);
        }

        private static void DrawRight(Graphics g, float colWidth, float colHeight, float x1, float y1, Pen p)
        {
            g.DrawLine(p, x1 + colWidth, y1, x1 + colWidth, y1 + colHeight);
        }

        private static void DrawLeft(Graphics g, float colHeight, float x1, float y1, Pen p)
        {
            g.DrawLine(p, x1, y1, x1, y1 + colHeight);
        }

        private static void DrawTop(Graphics g, float colWidth, float x1, float y1, Pen p)
        {
            g.DrawLine(p, x1, y1, x1 + colWidth, y1);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(_printerSettings == null)
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    _printerSettings = pd.PrinterSettings;
                }
            }
            if(_printerSettings != null)
            {
                printDoc.PrinterSettings = _printerSettings;
                printDoc.Print();
            }
        }

        [Flags]
        enum Borders
        {
            All = Top | Right | Left | Bottom,
            Top = 1,
            Right = 2,
            Left = 4,
            Bottom = 8
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int mXCount = (int)nbXCount.Value;
            int mYCount = (int)nbYCount.Value;

            watch.Start();
            _maze = new Maze(mXCount, mYCount);
            watch.Stop();
            lblGenerationTime.Text = watch.ElapsedMilliseconds.ToString();
            watch.Reset();

            btnPrint.Enabled = true;
        }
    }
}
