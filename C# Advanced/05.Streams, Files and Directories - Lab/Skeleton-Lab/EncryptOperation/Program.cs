using System;

namespace EncryptOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../Images";
            Encrypt(path);


        }
        static void Encrypt(string path)
        {
            using (FileStream read = new FileStream(path + "/download.jpg", FileMode.Open))
            {
                using (FileStream write = new FileStream(path + "/[e]download.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[1024];

                    while (read.Read(buffer, 0, buffer.Length) > 0)
                    {                        
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            buffer[i] ^= 157;
                        }
                        write.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}