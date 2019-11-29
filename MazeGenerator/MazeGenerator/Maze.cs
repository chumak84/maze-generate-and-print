using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
{
    public class Maze
    {
        private readonly int _xComponentCount;
        private readonly int _yComponentCount;
        private Dictionary<int, List<int>> _connections;

        public Maze(int xComponentCount, int yComponentCount)
        {
            _xComponentCount = xComponentCount;
            _yComponentCount = yComponentCount;

            GenerateMaze();
        }

        public int YComponentCount => _yComponentCount;
        public int XComponentCount => _xComponentCount;

        private void GenerateMaze()
        {
            Random r = new Random();

            int totalCount = _xComponentCount * _yComponentCount;
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

            if (current % _xComponentCount != 0)
            {
                int leftN = current - 1;
                if (leftN >= 0 && !visited[leftN])
                    unvisitedNeighbours.Add(leftN);
            }
            int topN = current - _xComponentCount;
            if (topN >= 0 && !visited[topN])
                unvisitedNeighbours.Add(topN);
            if (current % _xComponentCount != _xComponentCount - 1)
            {
                int rightN = current + 1;
                if (!visited[rightN])
                    unvisitedNeighbours.Add(rightN);
            }
            int bottomN = current + _xComponentCount;
            if (bottomN < _xComponentCount * _yComponentCount && !visited[bottomN])
            {
                unvisitedNeighbours.Add(bottomN);
            }
        }

    }
}
