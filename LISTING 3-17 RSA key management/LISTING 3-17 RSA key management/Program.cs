using System;
using System.Security.Cryptography;


namespace LISTING_3_17_RSA_key_management
{
    class Program
    {
        static void Main(string[] args)
        {
            string containerName = "KeyStore";

            CspParameters csp = new CspParameters();
            csp.KeyContainerName = containerName;
            // Create a new RSA to encrypt the data
            RSACryptoServiceProvider rsaStore = new RSACryptoServiceProvider(csp);
            Console.WriteLine("Stored keys: {0}", rsaStore.ToXmlString(includePrivateParameters: false));

            RSACryptoServiceProvider rsaLoad = new RSACryptoServiceProvider(csp);
            Console.WriteLine("Loaded keys: {0}", rsaLoad.ToXmlString(includePrivateParameters: false));
            Console.ReadKey();
        }
    }
}
