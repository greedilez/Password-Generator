using System;
using System.IO;
using System.Threading;

namespace PasswordGenerator
{
    class Program
    {
        private static string symbols = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890";

        private static string password = string.Empty;

        private static string version = "0.2";

        private static string filePath;

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("===========================================WELCOME TO PASSWORD GENERATOR===========================================");
            Console.WriteLine($"-VERSION: {version}");
            Console.WriteLine("-My github: github.com/greedilez");
            Console.WriteLine("Type here logs file path (file name with .txt):");
            filePath = Console.ReadLine();

            Console.WriteLine("Press s to Generate password:");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "S" || answer == "s")
                {
                    Console.WriteLine("Enter password length:");
                    try
                    {   
                        int length = Convert.ToInt32(Console.ReadLine());
                        if(length < 2)
                        {
                            Console.WriteLine("Too short! Press s to generate again.");
                        }
                        else if(length <= 100)
                        {
                            Console.WriteLine($"=======================YOUR PASSWORD: {GeneratedPassword(length)}=======================");
                            Console.WriteLine("Press s to generate again.");
                        }
                        else Console.WriteLine("Too long! Press s to generate again.");
                    }
                    catch
                    {
                        Console.WriteLine("Error! Press s to generate again.");
                    }
                }
            }
        }

        private static string GeneratedPassword(int length)
        {
            try
            {
                password = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    Random random = new Random();
                    password += symbols[random.Next(0, symbols.Length)];
                }

                Console.WriteLine("Save to logs? Y/N");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    AddGeneratedPasswordToLogs(password);
                }
                else
                {
                    Console.WriteLine("=======================PASSWORD WASN'T SAVED!=======================");
                }
            }
            catch
            {
                Console.WriteLine("=======================UNKNOWN ERROR, TRY AGAIN.=======================");
            }

            return password;
        }

        private static void AddGeneratedPasswordToLogs(string generatedPass)
        {
            string path = filePath;
            try
            {
                string writtenText;
                using (StreamReader reader = new StreamReader(path))
                {
                    writtenText = reader.ReadLine();
                }

                using (StreamWriter writer = new StreamWriter(path))
                {
                    if(writtenText != null)
                    {
                        writer.Write($"{writtenText} {generatedPass}");
                    }
                    else
                    {
                        writer.Write($"{generatedPass}");
                    }
                }

                Console.WriteLine("=======================PASSWORD ADDED TO LOGS SUCCESSFULLY!=======================");
            }
            catch
            {
                Console.WriteLine("=======================CANNOT WRITE FILE IN DIRECTORY, CHECK PATH OR TRY AGAIN.=======================");
            }
        }
    }
}
