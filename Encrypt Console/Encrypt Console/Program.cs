using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileDir = null;

            bool validDir = false;
            while (!validDir)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the directory that contains the file you want to be encrypted.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("File Directory: ");

                try
                {
                    fileDir = Console.ReadLine();
                    DirectoryInfo di = new DirectoryInfo(fileDir);
                    FileInfo[] fileInfo = di.GetFiles();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Files in directory: ");

                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (FileInfo fi in fileInfo)
                    {
                        Console.WriteLine("{0} ({1} bytes)", fi.Name, fi.Length);
                    }

                    validDir = true;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }

            string encryptFile = null;

            bool fileExists = false;
            while (!fileExists)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Which file do you want encrypted?");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("File: ");
                encryptFile = Console.ReadLine();

                if (File.Exists(fileDir + @"\" + encryptFile))
                {
                    fileExists = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("File not found. Would you like to go to a new directory?");
                    Console.ResetColor();
                    Console.Write(" (Yes or No)");

                    string reply = Console.ReadLine();
                    if (reply.ToUpper().Equals("YES"))
                    {
                        Console.Clear();
                        Main(args);
                    }
                    else if (reply.ToUpper().Equals("NO"))
                    {

                    }
                    else
                    {
                        Console.WriteLine("Please imput a yes or no.");
                    }
                }
            }

            bool yesOrNo = false;
            while (!yesOrNo)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Are you sure you want to encrypt this file?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (Yes or No?)");

                string answer = Console.ReadLine();
                if (answer.ToUpper().Equals("YES"))
                {
                    yesOrNo = true;
                    try
                    {
                        File.Encrypt(fileDir + @"\" + encryptFile);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                }
                else if (answer.ToUpper().Equals("NO"))
                {
                    Console.WriteLine("Restarting Program... Press enter to restart.");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("Please imput a yes or a no.");
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Done.");
            Console.ResetColor();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
