using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeFiles
{
    public static class FileUtils
    {
        public static FileInfo[] GetAllFiles(string path)
        {
            DirectoryInfo directories = new DirectoryInfo(path);
            return directories.GetFiles("*", SearchOption.TopDirectoryOnly);
        }


        public static string GetFolderToMove(FileInfo file, string arrangeBy)
        {
            string folderToMove = file.DirectoryName;
            string subFolder = file.CreationTime.ToString(arrangeBy);
            if (file.DirectoryName != null)
            {
                folderToMove = Path.Combine(file.DirectoryName, subFolder);
            }

            return folderToMove;
        }
    }
}
