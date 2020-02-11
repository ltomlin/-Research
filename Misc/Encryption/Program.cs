using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var plainText = "this is a test";

            SHA256 sha256 = SHA256Managed.Create();

            var inputBytes = UTF8Encoding.UTF8.GetBytes(plainText);

            var outputByes = sha256.ComputeHash(inputBytes);

            var returnVal = PrintByteArray(outputByes);
        }

        // Print the byte array in a readable format.
        public static string PrintByteArray(byte[] array)
        {
            int i;
            string output = "";
            for (i = 0; i < array.Length; i++)
            {
                output += String.Format("{0:X2}", array[i]);
                if ((i % 4) == 3) output += " ";
            }
            return output;
        }
    }
}
