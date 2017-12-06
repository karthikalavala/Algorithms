using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            solve(8, 8, 1, 1, 8, 8);
        }

        bool valid(int x, int y, int N, int M)
        {
            if (x <= 0 || y <= 0 || x > N || y > M)
                return false;
            return true;
        }

        public int bfs(pair<int, int> p1, pair<int, int> p2, pair<int, int> p3)
        {

            int N = p3.ff;
            int M = p3.ss;
            Queue<pair<pair<int, int>, int>> Que;
            Dictionary<pair<int, int>, bool> Vis;

            Que.Enqueue(mpa(p1, 0));

            while (Que.Count!=0)
            {

                pair<pair<int, int>, int> temp = Que.front();
                Que.pop();

                if (temp.ff.ff == p2.ff && temp.ff.ss == p2.ss)
                    return temp.ss;
                int x = temp.ff.ff;
                int y = temp.ff.ss;
                int dis = temp.ss + 1;


                if (Vis.count(mpa(x, y)))
                    continue;
                Vis[mpa(x, y)] = true;

                for (int i = 0; i < 8; ++i)
                {

                    int x1 = x + dx[i];
                    int y1 = y + dy[i];
                    if (valid(x1, y1, N, M))
                        Que.push(mpa(mpa(x1, y1), dis));
                }

            }

            return -1;
        }

        public int solve(int N, int M, int x1, int y1, int x2, int y2)
        {
            pair<int, int> p1 = new pair<int,int>();
            p1.ff = x1;
            p1.ss = y1;

            pair<int, int> p2 = new pair<int, int>();
            p2.ff = x2;
            p2.ss = y2;

            pair<int, int> p3 = new pair<int, int>();
            p3.ff = N;
            p3.ss = M;

            int ans = bfs(p1, p2, p3);
            return ans;
        }
    }
    class pair<T1, T2>
    {
        public int ff;
        public int ss;
    }
}
