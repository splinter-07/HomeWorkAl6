using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkAl6
{
    class Graph
    {
        List<Vertex> Vertices = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();
        public int VerticesCount => Vertices.Count;
        public int EdgeCount => Edges.Count;

        public void AddVertex(Vertex vertexName)
        {
            Vertices.Add(vertexName);
        }
        public void AddVertex(int vertexName)
        {
            Vertices.Add(new Vertex(vertexName));
        }

        public void verticesVisitedFalse()
        {
            foreach (var vertex in Vertices)
            {
                vertex.Visited = false;
            }
        }
        public Vertex FindVertex(int vertexName)
        {
            foreach (var vertex in Vertices)
            {
                if (vertex.Value.Equals(vertexName))
                {
                    return vertex;
                }
            }
            return null;
        }
        public void AddEdge(Vertex from, Vertex to, int weight = 1)
        {
            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }
        public void AddEdge(int from, int to, int weight = 1)
        {
            var fromVertexs = FindVertex(from);
            var toVertex = FindVertex(to);
            var edge = new Edge(fromVertexs, toVertex, weight);
            Edges.Add(edge);
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[Vertices.Count, Vertices.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Value-1;
                var column = edge.To.Value-1;
                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        public List<Vertex> GetVertexLists(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }

        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>
            { 
                start
            };

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVertexLists(vertex))
                {
                    if (list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }

            return list.Contains(finish);
        }

        public void Print(int vertex, int[,] matrix)
        {
            Console.Write($"Вершина {vertex + 1}. Смежна с вершинами:");
            //Console.Write($"{vertex +1}: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[vertex, i] != 0)
                    Console.Write($"  {i +1}");
        }

        public List<int> DFS(int value) // обход в глубину
        {
            verticesVisitedFalse();
            var list = new List<int>();
            var stack = new Stack<int>();
            stack.Push(value);
            Console.WriteLine("Начинаем обход с {0} вершины", value);
            while (stack.Count != 0)
            {
                value = stack.Pop();
                Console.WriteLine("Перешли к узлу {0}", value);
                list.Add(value);
                foreach (var vertex in GetVertexLists(FindVertex(value)))
                {
                    if (!vertex.Visited)
                    {
                        vertex.Visited = true;
                        stack.Push(vertex.Value);
                        Console.WriteLine("Добавили узел {0}", vertex);
                    }
                }
            }
            return list;
        }

        public List<int> BFS(int value) //Обход в ширину
        {
            verticesVisitedFalse();
            var list = new List<int>();
            var queue = new Queue<int>();

            queue.Enqueue(value);
            list.Add(value);
            Console.WriteLine("Начинаем обход с {0} вершины", value);
            while (queue.Count != 0)
            {
                
                value = queue.Peek();
                queue.Dequeue();
                Console.WriteLine("Перешли к узлу {0}", value);
                foreach (var vertex in GetVertexLists(FindVertex(value)))
                {
                    if (!vertex.Visited)
                    {
                        vertex.Visited = true;
                        queue.Enqueue(vertex.Value);
                        Console.WriteLine("Добавили узел {0}", vertex);
                        list.Add(vertex.Value);
                        
                    }
                }
                
                
            }
            return list;
        }
    }
}
