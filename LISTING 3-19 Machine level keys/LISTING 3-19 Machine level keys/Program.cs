using System;
using System.Security.Cryptography;

namespace LISTING_3_19_Machine_level_keys
{
    class Program
    {
        static void Main(string[] args)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "Machine Level Key";

            // Specify that the key is to be stored in the machine level key store
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

            // Create a crypto service provider
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams);

            Console.WriteLine(rsa.ToXmlString(includePrivateParameters: false));

            // Make sure that it is persisting keys
            rsa.PersistKeyInCsp = true;

            // Clear the provider to make sure it saves the key
            rsa.Clear();

            Console.ReadKey();
        }
    }
}
