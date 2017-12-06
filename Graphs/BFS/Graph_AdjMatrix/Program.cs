using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_AdjMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(5);
            g.addEdge(0, 1);
            g.addEdge(0, 4);
            g.addEdge(1, 2);
            g.addEdge(1, 3);
            g.addEdge(1, 4);
            g.addEdge(2, 3);
            g.addEdge(3, 4);
        }
    }

    class Graph
    {
        public int V;
        public List<int>[]  array;

        public Graph(int v)
        {
            this.V = v;
            array = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                array[i] = new List<int>();
            }
        }

        public void addEdge(int v, int u)
        {
            array[v].Add(u);
            array[u].Add(v);
        }

        public void PrintList()
        {

        }
    }

    class AdjList
    {

    }
}
