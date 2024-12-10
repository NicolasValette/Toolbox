using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Toolbox.Datas
{
    public class Graph<T>
    {
        private long _numberOfNode;
        private T _actualNode;
        protected T _startingNode;
        protected List<T> _finalNode;
        public long NumberOfMove = 0;

        public T Actual
        {
            get => _actualNode;
        }

        public T Starting
        {
            get => _startingNode;
        }

        public List<T> Final
        {
            get => _finalNode;
        }

        private Dictionary<string, LinkedList<T>> _edges;

        public long Count
        {
            get => _numberOfNode;
        }

        public Graph()
        {
            _edges = new Dictionary<string, LinkedList<T>>();
            _finalNode = new List<T>();
            NumberOfMove = 0;
        }

        public void AddEdge(T from, T to, bool verbose = false)
        {
            if (!_edges.ContainsKey(from.ToString()))
            {
                _edges[from.ToString()] = new LinkedList<T>();
                _numberOfNode++;
            }

            if (verbose) Console.WriteLine($"node : {from.ToString()}, add child : {to.ToString()}");
            _edges[from.ToString()].AddLast(to);
        }

        public void InitStartingNode(T startingNode)
        {
            _startingNode = startingNode;
        }

        public void AddFinalNode(T finalNode)
        {
            _finalNode.Add(finalNode);
        }

        public void InitGraph(T startingNode, List<T> finalNode)
        {
            _startingNode = startingNode;
            _actualNode = startingNode;
            _finalNode = finalNode;
            NumberOfMove = 0;
        }

        public bool IsFinish()
        {
            return (_actualNode.Equals(_finalNode));
        }

        public bool Move(string instrution)
        {
            for (int i = 0; i < instrution.Length; i++)
            {
                LinkedList<T> values = new LinkedList<T>();
                _edges.TryGetValue(_actualNode.ToString(), out values);
                if (instrution[i] == 'L')
                {
                    if (values != null)
                    {
                        _actualNode = values.First.Value;
                        NumberOfMove++;
                    }
                }
                else if (instrution[i] == 'R')
                {
                    if (values != null)
                    {
                        _actualNode = values.Last.Value;
                        NumberOfMove++;
                    }
                }

                if (_finalNode.Contains(_actualNode))
                {
                    return true;
                }
            }

            return false;
        }

        public void DepthSearchFromStart(T start)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            List<string> keys = new List<string>(_edges.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                visited.Add(keys[i], false);
            }

            DepthSearch(start, visited);
        }

        private void DepthSearch(T current, Dictionary<string, bool> visited)
        {
            visited[current.ToString()] = true;
            Console.WriteLine(" " + current.ToString());
            LinkedList<T> values = new LinkedList<T>();
            _edges.TryGetValue(current.ToString(), out values);
            foreach (T value in values)
            {
                if (visited[value.ToString()] == false)
                {
                    DepthSearch(value, visited);
                }
            }
        }

        public LinkedList<T> GetEdges(T node)
        {
            return _edges[node.ToString()];
        }

        public int FindLongestPath(T current, HashSet<string> visited, bool verbose = false)
        {
            int result = 0;
            if (Final.Contains(current))
            {
                return visited.Count;
            }

            foreach (var neighbour in _edges[current.ToString()])
            {
                if (visited.Add(neighbour.ToString()))
                {
                    int longestPath = FindLongestPath(neighbour, visited, verbose);
                    if (verbose && longestPath > 0) Console.WriteLine($"Path found, lenght : {longestPath}");
                    result = Math.Max(longestPath, result);
                    visited.Remove(neighbour.ToString());
                }
            }

            return result;
        }

        public List<int> FindLongestPathNonRec(HashSet<string> visited, bool verbose = false)
        {
            List<int> result = new List<int>();
            Stack<T> stack = new Stack<T>();
            stack.Push(_startingNode);
            
            while (stack.Count > 0)
            {
                T pos = stack.Pop();
                if (Final.Contains(pos))
                {
                    result.Add(visited.Count);
                    visited.Remove(pos.ToString());
                    continue;
                }

                foreach (var neighbour in _edges[pos.ToString()])
                {
                    if (visited.Add(neighbour.ToString()))
                    {
                        stack.Push(neighbour);
                        visited.Remove(neighbour.ToString());
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===Graph===");
            sb.AppendLine($"Starting Node : {Starting}");
            StringBuilder sbfinal = new StringBuilder();
            sbfinal.Append($"Final node : {Final[0].ToString()}");
            for (int i = 1; i < Final.Count; i++)
            {
                sbfinal.Append($", {Final[i].ToString()}");
            }

            sbfinal.Append(".");
            sb.AppendLine(sbfinal.ToString());
            sb.AppendLine();
            foreach (KeyValuePair<string, LinkedList<T>> node in _edges)
            {
                sb.Append($"{node.Key} = ({node.Value.First.Value}, {node.Value.First.Next.Value})\n");
            }

            sb.AppendLine("===========");
            return sb.ToString();
        }
    }
}