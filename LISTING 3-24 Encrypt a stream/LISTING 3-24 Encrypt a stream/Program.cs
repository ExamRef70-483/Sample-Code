using System;
using System.IO;
using System.Security.Cryptography;

namespace LISTING_3_24_Encrypt_a_stream
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
            string plainText = "This is my super super secret data";

            // byte array to hold the encrypted message
            byte[] encryptedText;

            // byte arrays to hold the key that was used for encryption
            byte[] key1;
            byte[] key2;

            // byte array to hold the initialization vector that was used for encryption
            byte[] initializationVector1;
            byte[] initializationVector2;

            using (Aes aes1 = Aes.Create())
            {
                // copy the key and the initialization vector
                key1 = aes1.Key;
                initializationVector1 = aes1.IV;

                // create an encryptor to encrypt some data
                ICryptoTransform encryptor1 = aes1.CreateEncryptor();

                // Create a new memory stream to receive the 
                // encrypted data. 

                using (MemoryStream encryptMemoryStream = new MemoryStream())
                {
                    // create a CryptoStream, tell it the stream to write to
                    // and the encryptor to use. Also set the mode
                    using (CryptoStream cryptoStream1 = new CryptoStream(encryptMemoryStream,
                        encryptor1, CryptoStreamMode.Write))
                    {
                        // Add another layer of encryption
                        using (Aes aes2 = Aes.Create())
                        {
                            // copy the key and the initialization vector
                            key2 = aes2.Key;
                            initializationVector2 = aes2.IV;

                            ICryptoTransform encryptor2 = aes2.CreateEncryptor();

                            using (CryptoStream cryptoStream2 = new CryptoStream(cryptoStream1, encryptor2, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(cryptoStream2))
                                {
                                    //Write the secret message to the stream.
                                    swEncrypt.Write(plainText);
                                }
                                // get the encrypted message from the stream
                                encryptedText = encryptMemoryStream.ToArray();
                            }
                        }
                    }
                }
            }

            // Dump out our data
            Console.WriteLine("String to encrypt: {0}", plainText);
            dumpBytes("Key1: ", key1);
            dumpBytes("Initialization Vector1: ", initializationVector1);
            dumpBytes("Key2: ", key2);
            dumpBytes("Initialization Vector2: ", initializationVector2);
            dumpBytes("Encrypted: ", encryptedText);

            // Now do the decryption
            string decryptedText;

            using (Aes aesd1 = Aes.Create())
            {
                // Configure the aes instances with the key and 
                // initialization vector to use for the decryption
                aesd1.Key = key1;
                aesd1.IV = initializationVector1;

                // Create a decryptor from aes1
                ICryptoTransform decryptor1 = aesd1.CreateDecryptor();

                using (MemoryStream decryptStream = new MemoryStream(encryptedText))
                {
                    using (CryptoStream decryptCryptoStream1 =
                        new CryptoStream(decryptStream, decryptor1, CryptoStreamMode.Read))
                    {
                        using (Aes aesd2 = Aes.Create())
                        {
                            // Configure the aes instances with the key and 
                            // initialization vector to use for the decryption
                            aesd2.Key = key2;
                            aesd2.IV = initializationVector2;

                            // Create a decryptor from aes2
                            ICryptoTransform decryptor2 = aesd2.CreateDecryptor();

                            using (CryptoStream decryptCryptoStream2 =
                                new CryptoStream(decryptCryptoStream1, decryptor2, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(decryptCryptoStream2))
                                {
                                    decryptedText = srDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Decrypted string: {0}", decryptedText);

                Console.ReadKey();
            }
        }
    }
}
