using System;
using System.IO;
using System.Security.Cryptography;

namespace CryptoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nAsymmetric example:\n");

            RsaExample.run();

            Console.WriteLine("\nSymmetric example:\n");

            AesExample.run();
        }
    }

    
}
