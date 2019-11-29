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

        int mXCount = 70;
        int mYCount = 100;
        Dictionary<int, List<int>> _connections;

        public Form1()
        {
            InitializeComponent();
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var rf = e.PageSettings.PrintableArea;
            var g = e.Graphics;
             
            float startX = 0f;
            float startY = 0f;
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
                    if (element != 0 && !_connections[element].Contains(element - mXCount))
                        DrawTop(g, colWidth, x1, y1, p);
                    if(!_connections[element].Contains(element - 1))
                        DrawLeft(g, colHeight, x1, y1, p);
                    if (!_connections[element].Contains(element + 1))
                        DrawRight(g, colWidth, colHeight, x1, y1, p);
                    if(element != lest && !_connections[element].Contains(element + mXCount))
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
            mXCount = (int)nbXCount.Value;
            mYCount = (int)nbYCount.Value;

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

        private void GenerateMaze()
        {
            Random r = new Random();

            int totalCount = mXCount * mYCount;
            bool[] visited = new bool[totalCount];
            _connections = new Dictionary<int, List<int>>(totalCount);
            List<int> unvisitedNeighbours = new List<int>(4);

            int current = 0;

            Stack<int> stack = new Stack<int>();
            //stack.Push(current);

            do
            {
                visited[current] = true;

                FillUnvisitedNeighbours(visited, unvisitedNeighbours, current);

                int un;
                if (unvisitedNeighbours.Count == 0)
                {
                    current = stack.Pop();
                    continue;
                }
                if (unvisitedNeighbours.Count == 1)
                {
                    un = unvisitedNeighbours[0];
                }
                else
                {
                    un = unvisitedNeighbours[r.Next(unvisitedNeighbours.Count)];
                }

                if (!_connections.ContainsKey(current))
                    _connections.Add(current, new List<int>());
                if (!_connections.ContainsKey(un))
                    _connections.Add(un, new List<int>());

                _connections[current].Add(un);
                _connections[un].Add(current);

                stack.Push(current);
                current = un;
            }
            while (stack.Count > 0);
        }

        private void FillUnvisitedNeighbours(bool[] visited, List<int> unvisitedNeighbours, int current)
        {
            unvisitedNeighbours.Clear();

            if (current % mXCount != 0)
            {
                int leftN = current - 1;
                if (leftN >= 0 && !visited[leftN])
                    unvisitedNeighbours.Add(leftN);
            }
            int topN = current - mXCount;
            if (topN >= 0 && !visited[topN])
                unvisitedNeighbours.Add(topN);
            if (current % mXCount != mXCount - 1)
            {
                int rightN = current + 1;
                if (!visited[rightN])
                    unvisitedNeighbours.Add(rightN);
            }
            int bottomN = current + mXCount;
            if(bottomN < mXCount * mYCount && !visited[bottomN])
            {
                unvisitedNeighbours.Add(bottomN);
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
