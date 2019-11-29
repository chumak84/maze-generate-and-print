using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        const int DEFAULT_MAZE_WIDTH = 70;
        const int DEFAULT_MAZE_HEIGHT = 100;

        Maze _maze;

        public Form1()
        {
            InitializeComponent();
            printDoc.PrintPage += PrintDoc_PrintPage;
            nbXCount.Value = DEFAULT_MAZE_WIDTH;
            nbYCount.Value = DEFAULT_MAZE_HEIGHT;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var rf = e.PageSettings.PrintableArea;
            var g = e.Graphics;

            int mXCount = _maze.XComponentCount;
            int mYCount = _maze.YComponentCount;

            float width = rf.Width;
            float height = rf.Height;
            float colWidth = width / _mXCount;
            float colHeight = height / _mYCount;

            float x1 = 0;
            //float x2 = colWidth;
            float y1 = 0;
            //float y2 = colHeight;

            Pen p = Pens.Black;
            int element = 0;
            int lest = _mXCount * _mYCount - 1;
            for(int iY = 0; iY < _mYCount; iY++)
            {
                x1 = 0;
                for(int iX = 0; iX < _mXCount; iX++)
                {
                    if (element != 0 && !_connections[element].Contains(element - _mXCount))
                        DrawTop(g, colWidth, x1, y1, p);
                    if(!_connections[element].Contains(element - 1))
                        DrawLeft(g, colHeight, x1, y1, p);
                    if (!_connections[element].Contains(element + 1))
                        DrawRight(g, colWidth, colHeight, x1, y1, p);
                    if(element != lest && !_connections[element].Contains(element + _mXCount))
                        DrawBottom(g, colWidth, colHeight, x1, y1, p);
                    element++;
                    x1 += colWidth;
                }
                y1 += colHeight;
            }
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
            _mXCount = (int)nbXCount.Value;
            _mYCount = (int)nbYCount.Value;

            GenerateMaze();

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
    }
}
