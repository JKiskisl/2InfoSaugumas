using System;
using System.IO;
using System.Text;

namespace DES
{
    class Program
    {
        #region "txt"
        public static void Ch2()
        {
            Console.WriteLine("Choose option: ");
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");
            Console.WriteLine("9. to exit");
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Type in unecrpyted message");
            string unencrypt = Console.ReadLine();
            string encryptedstring;
            string decryptedstring;


            Console.WriteLine("Type in password");
            string password = Console.ReadLine();

            Console.WriteLine("Encrypt");
            Console.WriteLine("Unencrypted String: " + unencrypt);
            Console.WriteLine("password: " + password);
            string path = "C:\\Users\\smics\\Desktop\\DES CIPHER\\Encryptedstring.txt";


            Ch2();

            int x = Convert.ToInt32(Console.ReadLine());
            while (x!=9)
            {
                switch (x)
                {
                    case 1:
                        encryptedstring = DESCiph.Encrypt(unencrypt, password);
                        Console.WriteLine("Encrypted String: " + encryptedstring);
                        #region "FileWrite"
                        Console.WriteLine("Save Encryted string in file?");
                        Console.WriteLine("Y/N");
                        string answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            using (StreamWriter writer = new StreamWriter(path))
                            {
                                writer.WriteLine(encryptedstring);
                                writer.Close();
                            }
                        }
                        else
                        {
                            break;
                        }
                        #endregion
                        break;
                    case 2:
                        #region "FileRead"
                        Console.WriteLine("Read decrypted string from file?");
                        Console.WriteLine("Y/N");
                        string answer2 = Console.ReadLine();
                        if (answer2 == "Y")
                        {
                            string temp;
                            string temp2;
                            using (StreamReader reader = new StreamReader(path))
                            {
                                temp = reader.ReadLine();
                                reader.Close();
                            }
                            temp2 = DESCiph.Decrypt(temp, password);
                            Console.WriteLine("Decrypted string from file: " + temp2);
                        }
                        else
                        {
                            encryptedstring = DESCiph.Encrypt(unencrypt, password);
                            decryptedstring = DESCiph.Decrypt(encryptedstring, password);
                            Console.WriteLine("Decrypted string: " + decryptedstring);
                            break;
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
                Ch2();
                x = Convert.ToInt32(Console.ReadLine());
            }

            
        }
    }
}
