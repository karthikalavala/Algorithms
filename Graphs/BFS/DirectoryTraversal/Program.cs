using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            DFS_Directories dfs = new DFS_Directories();
            dfs.GetFilesFromDFS("D:\\DirectoryFolder");

            BFS_Directories bfs = new BFS_Directories();
            bfs.GetFilesFromBFS("D:\\DirectoryFolder");
            Program p = new Program();
            p.TraverseDirectoriesForFiles("D:\\DirectoryFolder"); ;
            p.TraverseDirectories("D:\\DirectoryFolder");
        }

        public void TraverseDirectories(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath), string.Empty);
        }

        public void TraverseDirectoriesForFiles(string directoryPath)
        {
            TraverseDirAndPrintFilesOnly(directoryPath);
        }

        public void TraverseDir(DirectoryInfo dir, string spaces)
        {
            Console.WriteLine(string.Empty + dir.FullName);

            DirectoryInfo[] children = dir.GetDirectories();

            foreach (DirectoryInfo child in children)
            {
                TraverseDir(child, spaces + "  ");
            }
        }

        public void TraverseDirAndPrintFilesOnly(string directoryPath)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(directoryPath))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        bool b = Directory.Exists(dir);
                        Console.WriteLine(file);
                    }
                    TraverseDirAndPrintFilesOnly(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
