using System;
using System.Text;

namespace Messenger_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Привет!Привет!Привет!Привет!Привет!Привет!Привет!";
            var e = Encoding.UTF8.GetByteCount("Привет!");
            var buffer = new byte[256];
            buffer = Encoding.UTF8.GetBytes(test);
            

            string response = Encoding.UTF8.GetString(buffer, 13, buffer.Length-e);
            var end = 5;
            end++;
        }
    }
}
