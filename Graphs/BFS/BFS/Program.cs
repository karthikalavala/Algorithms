using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphAdjList g = new GraphAdjList(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            BreadthFirstSearch bfs = new BreadthFirstSearch(g, 2);
        }
    }
    class BreadthFirstSearch
    {
        public int[] edgeTo;
        public int[] distTo;
        public int s;


        //Here there one additional array "distTo" which tells you how many edges there is to "v" vertex from starting "s" vertex.

        //I use Adjacency List Graph so if you want to test code provided below or solve some problems you can use this Graph :
        public BreadthFirstSearch(GraphAdjList G, int s)
        {
            edgeTo = new int[G.VertexCount];
            distTo = new int[G.VertexCount];
            for (int i = 0; i < G.VertexCount; i++)
            {
                distTo[i] = -1;
                edgeTo[i] = -1;
            }

            this.s = s;
            BFSearch(G, s);
        }

        public void BFSearch(GraphAdjList G, int S)
        {
            var queue = new Queue<int>();
            queue.Enqueue(S);
            distTo[S] = 0;

            while(queue.Count!=0)
            {
                int v = queue.Dequeue();
                Console.Write(v + " ");
                foreach(var w in G.GetAdj(v))
                {
                    if (distTo[w] == -1)
                    {
                        queue.Enqueue(w);
                        distTo[w] = distTo[v] + 1;
                        edgeTo[w] = v;
                    }
                }
            }
        }
    }

    public class GraphAdjList
    {
        private readonly int V;
        private readonly List<int>[] Adj;

        public GraphAdjList(int v)
        {
            this.V = v;
            Adj = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                Adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            Adj[v].Add(w);
            //Adj[w].Add(v);
        }

        public List<int> GetAdj(int v)
        {
            return Adj[v];
        }
        public int VertexCount
        {
            get
            {
                return V;
            }
        }
    }
}
