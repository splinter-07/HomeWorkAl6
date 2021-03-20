using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkAl6
{
    public class Edge //Ребро
    {
        public int Weight { get; set; } // вес связи
        public Vertex From { get; set; }
        public Vertex To { get; set; }

        public Edge(Vertex from, Vertex to, int weight)
        {
            Weight = weight;
            From = from;
            To = to;

        }
        public override string ToString()
        {
            return $"({From};{To})";
        }
    }
}
