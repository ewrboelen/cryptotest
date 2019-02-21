using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace CryptoTest
{
    public class RsaExample
    {
        static int KEYSIZE = 1024;
        static RSAEncryptionPadding ENCRYPTIONTYPE = RSAEncryptionPadding.OaepSHA256;

        public static void run(){
            string original = "Here is some data to encrypt!";

            using (RSA myRsa = RSA.Create())
            {
                myRsa.KeySize = KEYSIZE;
                RSAParameters mparams = myRsa.ExportParameters(true);  

                Console.WriteLine("public modulus: "+Convert.ToBase64String(mparams.Modulus)+" exponent: "+Convert.ToBase64String(mparams.Exponent));

                Console.WriteLine("private P: "+Convert.ToBase64String(mparams.P)+" Q: "+Convert.ToBase64String(mparams.Q));
                Console.WriteLine("private DP: "+Convert.ToBase64String(mparams.DP)+" DQ: "+Convert.ToBase64String(mparams.DQ));

                byte[] visData = Encoding.ASCII.GetBytes(original);
                byte[] secData = myRsa.Encrypt(visData,ENCRYPTIONTYPE);

                Console.WriteLine("\nencrypted: "+Convert.ToBase64String(secData));

                byte[] resData = myRsa.Decrypt(secData,ENCRYPTIONTYPE);
                Console.WriteLine("decrypted: "+Encoding.ASCII.GetString(resData));

            }
        }
    }
}