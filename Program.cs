using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            const string nameA = "Bury St Edmonds";
            const string nameB = "Stowmarket";
            const string nameC = "Ipswitch";
            const string nameD = "Framlingham";
            const string nameE = "Woodbridge";
            const string nameF = "Wickham Market";

            UndirectedMatrixGraph graph = new UndirectedMatrixGraph(nameA, 0);
            List<int> B = new List<int> { 25, 0 };
            List<int> C = new List<int> { 45, 21, 0 };
            List<int> D = new List<int> { 57, 0, 31, 0 };
            List<int> E = new List<int> { 56, 0, 15, 0, 0 };
            List<int> F = new List<int> { 0, 0, 0, 10, 9, 0 };

            graph.AddNode(nameB, B);
            graph.AddNode(nameC, C);
            graph.AddNode(nameD, D);
            graph.AddNode(nameE, E);
            graph.AddNode(nameF, F);

            graph.PrintMatrix();
            Console.WriteLine("");

            Console.WriteLine(graph.NeighbourCheck(nameA, nameB));
            Console.WriteLine(graph.NeighbourDistance(nameA, nameB));
            Console.WriteLine(graph.NeighbourCheck(nameA, nameF));
            Console.WriteLine(graph.NeighbourDistance(nameA, nameF));
            Console.WriteLine("");

            graph.RemoveNode(nameA);
            graph.RemoveNode(nameD);

            graph.PrintMatrix();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
