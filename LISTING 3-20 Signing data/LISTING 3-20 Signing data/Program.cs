using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace LISTING_3_20_Signing_data
{
    class Program
    {
        static void dumpBytes(string title, byte[] bytes)
        {
            Console.Write(title);
            foreach (byte b in bytes)
            {
                Console.Write("{0:X} ", b);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // This will convert our input string into bytes and back
            ASCIIEncoding converter = new ASCIIEncoding();

            // Get a crypto provider out of the certificate store

            X509Store store = new X509Store("demoCertStore", StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadOnly);

            X509Certificate2 certificate = store.Certificates[0];

            RSACryptoServiceProvider encryptProvider = certificate.PrivateKey as RSACryptoServiceProvider;

            string  messageToSign = "This is the message I want to sign";
            Console.WriteLine("Message: {0}", messageToSign);

            byte[] messageToSignBytes = converter.GetBytes(messageToSign);
            dumpBytes("Message to sign in bytes: ", messageToSignBytes);

            // need to calculate a hash for this message - this will go into the 
            // signature and be used to verify the message
            // Create an implementation of the hashing agorithm we are going to use
            HashAlgorithm hasher = new SHA1Managed();
            // Use the hasher to hash the message
                byte[] hash = hasher.ComputeHash(messageToSignBytes);
                dumpBytes("Hash for message: ", hash);

            // Now sign the hash to create a signature
            byte[] signature = encryptProvider.SignHash(hash,CryptoConfig.MapNameToOID("SHA1"));
            dumpBytes("Signature: ", messageToSignBytes);

            // We can send the signature along with the message to authenticate it
            // Create a decryptor that uses the public key 
            RSACryptoServiceProvider decryptProvider = certificate.PublicKey.Key as RSACryptoServiceProvider;

            // Now use the signature to perform a successful validation of the message
            bool validSignature = decryptProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
            Console.WriteLine("Correct signature validated OK: {0}", validSignature);

            // Change one byte of the signature 
            signature[0] = 99;
            // Now try the using the incorrect signature to validate the message
            bool invalidSignature = decryptProvider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
            Console.WriteLine("Incorrect signature validated OK: {0}", invalidSignature);

            Console.ReadKey();
        }
    }
}
