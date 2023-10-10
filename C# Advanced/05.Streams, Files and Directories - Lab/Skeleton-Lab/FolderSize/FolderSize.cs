namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);

        }
        public static void GetFolderSize(string folderPath, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine($"{GetFolderSize(new DirectoryInfo(folderPath)) / 1024.0} KB");
            }
        }

        public static long GetFolderSize(DirectoryInfo folderPath)
        {
            long bytes = 0;

            FileInfo[] fileInfo = folderPath.GetFiles();

            foreach (var file in fileInfo)
            {
                bytes += file.Length;
            }
            DirectoryInfo[] subDirectories = folderPath.GetDirectories();

            foreach (var subDirectory in subDirectories)
            {
                bytes += GetFolderSize(new DirectoryInfo(subDirectory.FullName));
            }
            return bytes;
        }
    }
}
