using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BFS_Directories
    {
        public void GetFilesFromBFS(string directoryPath)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(directoryPath);

            while (queue.Count > 0)
            {
                string path = queue.Dequeue();

                try
                {
                    foreach (string subpath in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subpath);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }

                try
                {
                    string[] files = Directory.GetFiles(path);

                    for(int i=0; i< files.Length; i++)
                    {
                        Console.WriteLine(files[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }
    }
}
