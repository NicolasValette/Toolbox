using System;
using System.Collections.Generic;
using Toolbox.Datas;

namespace Toolbox.Utilities.Algorythms
{
    public class Dijkstra
    {
        private char[][] _map;
        private char _separator;
        private char _freeSpace;
        private int _sizeX;
        private int _sizeY;

        private Coord2D<int> _startingPoint;
        private Coord2D<int> _endingPoint;

        private Dictionary<string, int> _distance = new Dictionary<string, int>();
        private Dictionary<string, Coord2D<int>> _previous = new Dictionary<string, Coord2D<int>>();
        
        public Dijkstra(char[][] map, char wallSeparator, char freeSpace, Coord2D<int> start, Coord2D<int> end)
        {
            _map = map;
            _separator = wallSeparator;
            _freeSpace = freeSpace;
            _startingPoint = start;
            _endingPoint = end;
        }

        private void Init()
        {
            for (int i = 0; i < _map.Length; i++)
            {
                for (int j = 0; j < _map[i].Length; j++)
                {
                    if (_map[i][j] == '.')
                    {
                        _distance.Add(new Coord2D<int>(i, j).ToString(), int.MaxValue);
                    }
                }
            }

            _distance[_startingPoint.ToString()] = 0;
        }

        private Coord2D<int> FindMinimalDistNode(List<Coord2D<int>> listNodes)
        {
            int minimum = int.MaxValue;
            Coord2D<int> currentNode = null;
            foreach (var node in listNodes)
            {
                if (_distance[node.ToString()] <= minimum)
                {
                    minimum = _distance[node.ToString()];
                    currentNode = node;
                }
            }
            return currentNode;
        }


        private void UpdateDist(Coord2D<int> node1, Coord2D<int> node2)
        {
            int weight = 1;
          

            if (_distance[node2.ToString()] > _distance[node1.ToString()] + weight)
            {
                _distance[node2.ToString()] = _distance[node1.ToString()] + weight;
                if (!_previous.ContainsKey(node2.ToString()))
                    _previous.Add(node2.ToString(), node1);
            }
        }

        private List<Coord2D<int>> Neighbours(List<Coord2D<int>> currentListCoord, Coord2D<int> currentPos)
        {
            List<Coord2D<int>> neighbours = new List<Coord2D<int>>();

            foreach (var node in currentListCoord)
            {
                if ((node.X == currentPos.X && node.Y == currentPos.Y - 1) ||
                    (node.X == currentPos.X && node.Y == currentPos.Y + 1) ||
                    (node.X == currentPos.X - 1 && node.Y == currentPos.Y) ||
                    (node.X == currentPos.X + 1 && node.Y == currentPos.Y))
                {
                    neighbours.Add(node);
                }
            }

            return neighbours;
        }


        public List<Coord2D<int>> Run()
        {
            Init();
            var Q = new List<Coord2D<int>>();
            for (int i = 0; i < _map.Length; i++)
            {
                for (int j = 0; j < _map[i].Length; j++)
                {
                    if (_map[i][j] == _freeSpace)
                        Q.Add(new Coord2D<int>(i, j));
                }
            }

            while (Q.Count > 0)
            {
                var node = FindMinimalDistNode(Q);
                Q.Remove(node);
                foreach (var element in Neighbours(Q, node))
                { 
                    UpdateDist(node, element);
                }
            }

            List<Coord2D<int>> path = new List<Coord2D<int>>();
            Coord2D<int> currentNode = _endingPoint;
            while (currentNode != _startingPoint)
            {
                path.Add(currentNode);
                if (!_previous.ContainsKey(currentNode.ToString()))
                    return null;
                currentNode = _previous[currentNode.ToString()];
            }
            path.Add(_startingPoint);
            path.Reverse();
            return path;

        }
    }
}