using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForGraphs
{
    class UndirectedMatrixGraph
    {
        private List<string> Nodes;
        private List<List<int>> Matrix;
        private int Size;

        public UndirectedMatrixGraph(string node1, int selfConnection)
        {
            Size = 1;
            Nodes = new List<string> { node1 };
            Matrix = new List<List<int>> { new List<int> { selfConnection } };
        }

        public void AddNode(string nodeName, List<int> connections)
        {
            if (connections.Count == Size + 1)
            {
                for (int i = 0; i < Size; i++)
                {
                    Matrix[i].Add(connections[i]);
                }

                Nodes.Add(nodeName);
                Size++;
                Matrix.Add(connections);
            }
        }

        public void RemoveNode(string nodeName)
        {
            int index = NodeLookup(nodeName);

            if (index > -1)
            {
                Nodes.RemoveAt(index);
                Matrix.RemoveAt(index);
                Size--;

                for (int i = 0; i < Size; i++)
                {
                    Matrix[i].RemoveAt(index);
                }
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.Write(EqualWrite(Nodes[i] + ":", 20));

                for (int j = 0; j < Size; j++)
                {
                    Console.Write(EqualWrite(Matrix[i][j].ToString(), 6));
                }

                Console.WriteLine("");
            }
        }

        public bool NeighbourCheck(string nodeA, string nodeB)
        {
            int indexA = NodeLookup(nodeA);
            int indexB = NodeLookup(nodeB);
            bool neighbours = false;

            if (indexA >= 0 && indexB >= 0)
            {
                if (Matrix[indexA][indexB] != 0)
                {
                    neighbours = true;
                }
            }

            return neighbours;
        }

        public int NeighbourDistance(string nodeA, string nodeB)
        {
            int indexA = NodeLookup(nodeA);
            int indexB = NodeLookup(nodeB);
            int weight = int.MinValue;
            bool neighbours = NeighbourCheck(nodeA, nodeB);

            if (neighbours)
            {
                weight = Matrix[indexA][indexB];
            }

            return weight;
        }

        private int NodeLookup(string nodeName)
        {
            int index = int.MinValue;

            for (int i = 0; i < Size; i++)
            {
                if (Nodes[i] == nodeName)
                {
                    index = i;
                    i = int.MaxValue - 1;
                }
            }

            return index;
        }

        private string EqualWrite(string input, int length)
        {
            return input.PadRight(length);
        }
    }
}
