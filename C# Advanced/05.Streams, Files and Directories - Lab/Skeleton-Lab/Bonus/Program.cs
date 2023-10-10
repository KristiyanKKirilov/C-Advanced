using System.IO;
using System.Text;

namespace Bonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("../../../text1.txt", FileMode.Create))
            {
                string text = "I want to rename this text";

                byte[] buffer = Encoding.UTF8.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
            }

            using (FileStream stream1 = new FileStream("../../../text1.txt", FileMode.Open))
            {
                byte[] buffer = new byte[stream1.Length];
                stream1.Read(buffer, 0, buffer.Length);
                string text = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(text);
            }
        }
    }
}