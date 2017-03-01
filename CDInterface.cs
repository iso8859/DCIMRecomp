using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace uData
{
    public abstract class CDInterface
    {
        public abstract string[] Compress(string[] files, string password, int volume, string destPath, string destName);
        public abstract string[] Decompress(string file, string password, string destPath);

        static public void CreateDirectoryRecurse(string path)
        {
            string[] items = path.Split('\\');
            int index = 0;
            string sep = "";
            StringBuilder path2 = new StringBuilder();
            do
            {
                path2.Append(sep);
                path2.Append(items[index++]);
                sep = "\\";
                PInvoke.CreateDirectory(path2.ToString(), IntPtr.Zero);
            }
            while (index < items.Length);
        }

        static public void CreateDirectoryForFile(string path)
        {
            CreateDirectoryRecurse(System.IO.Path.GetDirectoryName(path));
        }

        static public void EmptyDirectory(string path)
        {
            CreateDirectoryRecurse(path);
            string[] files = System.IO.Directory.GetFiles(path);
            foreach (string file in files)
            {
                PInvoke.SetFileAttributes(file, 0x80); // FILE_ATTRIBUTE_NORMAL
                File.Delete(file);
            }
        }

        static public void FileList2CRLFFile(List<string> files, string destFile)
        {
            using (StreamWriter sw = new StreamWriter(destFile, false, Encoding.ASCII))
            {
                foreach (string file in files)
                    sw.WriteLine(files);
            }
        }
    }
}
