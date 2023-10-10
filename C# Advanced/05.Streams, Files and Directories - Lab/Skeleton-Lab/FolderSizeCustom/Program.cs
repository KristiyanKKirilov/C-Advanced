using System;

namespace FolderSizeCustom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folder = Console.ReadLine();

            long size = FolderSize(folder);
            Console.WriteLine($"{size/1024.0/1024.0} MB");
        }

        static long FolderSize(string folder)
        {
            long bytes = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            FileInfo[] fileInfo = dirInfo.GetFiles();

            foreach (var file in fileInfo)
            {
                bytes += file.Length;
            }
            DirectoryInfo[] subDirectories = dirInfo.GetDirectories();

            foreach (var subDirectory in subDirectories)
            {
                bytes += FolderSize(subDirectory.FullName);
            }
            return bytes;
        }
    }
}