using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class DFS_Directories
    {
        public void GetFilesFromDFS(string directoryPath)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push(directoryPath);

            while (stack.Count != 0)
            {
                string path = stack.Pop();

                //get all files from the path
                string[] files = Directory.GetFiles(path);
                for(int i=0; i< files.Length; i++)
                {
                    Console.WriteLine(path);
                    Console.WriteLine(files[i]);
                }
                
                //if this is a directories, push all sub folders
                if (Directory.Exists(path))
                {
                    foreach (string subpath in Directory.GetDirectories(path))
                    {
                        stack.Push(subpath);
                    } 
                }
            }
        }
    }
}
