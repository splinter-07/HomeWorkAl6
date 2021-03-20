using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkAl6
{
    public class Vertex // Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //Исходящие связи
        public bool Visited { get; set; }
        public Vertex(int value)
        {
            Value = value;
            Edges = new List<Edge>();
        }
        public void AddEdge(Edge newEdge)
        {
            Edges.Add(newEdge);
        }
        public void AddEdge(Vertex from, Vertex to, int weight)
        {
            AddEdge(new Edge(from, to, weight));
        }
        public override string ToString() => Value.ToString();

    }
}
