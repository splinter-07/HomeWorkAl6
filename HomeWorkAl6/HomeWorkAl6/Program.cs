using System;
using System.Collections.Generic;

namespace HomeWorkAl6
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Граф 1");
            var graph1 = new Graph();
            
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            graph1.AddVertex(v1);
            graph1.AddVertex(v2);
            graph1.AddVertex(v3);
            graph1.AddVertex(v4);
            graph1.AddVertex(v5);
            graph1.AddVertex(v6);
            graph1.AddVertex(v7);

            graph1.AddEdge(v1, v2, 5);
            graph1.AddEdge(v1, v3, 5);
            graph1.AddEdge(v3, v4, 6);
            graph1.AddEdge(v2, v5, 7);
            graph1.AddEdge(v2, v6, 7);
            graph1.AddEdge(v6, v5, 8);
            graph1.AddEdge(v5, v6, 9);

            PrintMatrix(graph1);

            Console.WriteLine();
            Console.WriteLine("*** DFS ***");
            Console.WriteLine();
            Print(graph1.DFS(1));
            Console.WriteLine();
            Console.WriteLine("Ожидание: 1 3 4 2 6 5 ");


            Console.WriteLine();
            Console.WriteLine("*** BFS ***");
            Console.WriteLine();
            Print(graph1.BFS(1));
            Console.WriteLine();
            Console.WriteLine("Ожидание: 1 2 3 5 6 4");

            Console.WriteLine("Граф 2");
            var graph2 = new Graph();

            graph2.AddVertex(1);
            graph2.AddVertex(2);
            graph2.AddVertex(3);
            graph2.AddVertex(4);
            graph2.AddVertex(5);
            graph2.AddVertex(6);
            graph2.AddVertex(7);

            graph2.AddEdge(1, 2, 22);
            graph2.AddEdge(1, 3, 33);
            graph2.AddEdge(1, 4, 61);
            graph2.AddEdge(2, 3, 47);
            graph2.AddEdge(2, 5, 93);
            graph2.AddEdge(3, 4, 11);
            graph2.AddEdge(3, 5, 79);
            graph2.AddEdge(3, 6, 63);
            graph2.AddEdge(4, 6, 41);
            graph2.AddEdge(5, 6, 17);
            graph2.AddEdge(5, 7, 58);
            graph2.AddEdge(6, 7, 84);

            PrintMatrix(graph2);


            Console.WriteLine();
            Console.WriteLine("*** DFS ***");
            Console.WriteLine();
            Print(graph2.DFS(1));
            Console.WriteLine();
            Console.WriteLine("Ожидание: 1 4 6 7 3 5 2");


            Console.WriteLine();
            Console.WriteLine("*** BFS ***");
            Console.WriteLine();
            Print(graph2.BFS(1));
            Console.WriteLine();
            Console.WriteLine("Ожидание: 1 2 3 4 5 6 7");


            Console.ReadLine();

        }

        private static void Print(List<int> list)
        {
            Console.WriteLine("Реальность: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
        private static void GetVertex(Graph graph, Vertex vertex)
        {
            
            Console.Write(vertex.Value + ": ");
            foreach (var v in graph.GetVertexLists(vertex))
            {
                Console.Write(v.Value + " ");
            }
            Console.WriteLine();
        }
        private static void GetVertex(Graph graph, int value)
        {
            var vertex = graph.FindVertex(value);
            
            Console.Write(vertex.Value + ": ");
            foreach (var v in graph.GetVertexLists(vertex))
            {
                Console.Write(v.Value + " ");
            }
            Console.WriteLine();
        }
        private static void PrintMatrix(Graph graph)
        {
            Console.WriteLine("  ");
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                Console.Write($"\t {i + 1}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------------------");
            //Console.WriteLine(" ");
            var matrix = graph.GetMatrix();
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                Console.Write(i + 1 + " |");
                  for (int j = 0; j < graph.VerticesCount; j++)
                  {
                      Console.Write($"\t {matrix[i, j]}");
                  }
                   Console.WriteLine();
             }
        }
    }
}
