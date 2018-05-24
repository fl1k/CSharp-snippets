using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Recursive_Filesearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // An example, search all patritions for .txt files
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))
            {
                List<string> files = SearchDirectoriesFiletype(d.RootDirectory.FullName, ".txt");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            Console.WriteLine("\nDone...");
            Console.ReadLine();
        }

        static List<string> SearchDirectoriesFilename(string path, string term)
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path).Where(x => x.Contains(term)))
            {
                try
                {
                    files.Add(file);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }
            foreach (string subdir in Directory.EnumerateDirectories(path))
            {
                try
                {
                    files.AddRange(SearchDirectoriesFilename(subdir, term));
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }
            return files;
        }

        //
        //
        //
        //
        //
        //

        static List<string> SearchDirectoriesFiletype(string path, string term)
        {
            List<string> files = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path).Where(x => x.EndsWith(term)))
            {
                try
                {
                    files.Add(file);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }
            foreach (string subdir in Directory.EnumerateDirectories(path))
            {
                try
                {
                    files.AddRange(SearchDirectoriesFiletype(subdir, term));
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }
            return files;
        }
    }
}
