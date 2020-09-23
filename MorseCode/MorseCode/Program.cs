using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MorseCode
{
    class Program
    {
        static char[] letters = { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '&', '\'', '@', ')', '(', ':', ',', '=', '!', '.', '-', '+', '"', '?', '/' };
        static string[] morse = { "| ", ".- ", "-... ", "-.-. ", "-.. ", ". ", "..-. ", "--. ", ".... ", ".. ", ".--- ", "-.- ", ".-.. ", "-- ", "-. ", "--- ", ".--. ", "--.- ", ".-. ", "... ", "- ", "..- ", "...- ", ".-- ", "-..- ", "-.-- ", "--.. ", "----- ", ".---- ", "..--- ", "...-- ", "....- ", "..... ", "-.... ", "--... ", "---.. ", "----. ", ".-... ", ".----. ", ".--.-. ", "-.--.- ", "-.--. ", "---... ", "--..-- ", "-...- ", "-.-.-- ", ".-.-.- ", "-....- ", ".-.-. ", ".-..-. ", "..--.. ", "-..-. " };
        static void Main(string[] args)
        {
            MakeAChoice();

            static void MakeAChoice()
            {
                Green();
                Console.WriteLine("If you wish to convert a message into Morse Code push the letter 'A' on the keybord.");
                Console.WriteLine("If you wish to decode a message from Morse Code push the letter 'B' instead.");
                Console.ResetColor();
                string choice = "";
                while (choice != "A" || choice != "B")
                {
                    choice = Console.ReadLine().ToUpper();
                    if (choice == "A")
                    {
                        ToMorse();
                    }
                    else if (choice == "B")
                    {
                        FromMorse();
                    }
                    else if (choice != "A" || choice != "B")
                    {
                        Green();
                        Console.WriteLine("Invalid choice.  Please choose either 'A' or 'B' from the keybord.");
                        Console.ResetColor();
                    }
                }
            }

            static void ToMorse()
            {
                Green();
                Console.WriteLine("Please enter a message and it will be turned into Morse Code" +
                    ".");
                Red();
                Console.WriteLine("Do NOT use the following symbols: #, $, %, ^, *, <, >, {, }, [, ], |, ~, `, \", _ ");
                Console.WriteLine("Invalid symbols will return an empty space.");
                Console.ResetColor();
                string inputMessage = Console.ReadLine().ToUpper();
                string theMessage = "";

                for (int i = 0; i < inputMessage.Length; i++)
                {
                    for (int m = 0; m < 51; m++)
                    {
                        if (inputMessage[i] == letters[m])
                        {
                            theMessage += morse[m];
                            break;
                        }
                    }
                }
                Green();
                Console.WriteLine($"The message in Morse Code is below.  The \"|\" indicates a word break.");
                Console.ResetColor();
                Console.WriteLine(theMessage);
                KeepGoing();
            }
            static void FromMorse()
            {
                Green();
                Console.WriteLine($"Enter your message in Morse Code.  Use \".\" and \"-\" with a space after each Morse letter.");
                Console.WriteLine($" Use \"| \" to indicate a space between words.");
                Red();
                Console.WriteLine($"For example, \"Hello World\" appears as: .... . .-.. .-.. --- | .-- --- .-. .-.. -.. ");
                Console.WriteLine("Invalid Morse characters are returned as an empty space.");
                Console.ResetColor();

                string inputMessage = Console.ReadLine();
                string theMessage = "";
                string[] morseLetter = inputMessage.Split(" ");

                for (int i = 0; i < morseLetter.Length; i++)
                {
                    for (int m = 0; m < 51; m++)
                    {
                        if ((morseLetter[i] + " ") == (morse[m]))//needed " " to match morse[] 
                        {
                            theMessage += letters[m];
                            break;
                        }
                    }
                }
                Green();
                Console.WriteLine($"The translated Morse Code message is below.");
                Console.ResetColor();
                Console.WriteLine(theMessage);
                KeepGoing();
            }
            static void KeepGoing()
            {
                Green();
                Console.WriteLine("Keep going?  Enter 'Y' to continue or 'N' to exit.");
                Console.ResetColor();
                string cont = "";
                
                while (cont != "Y" || cont != "N")
                {
                    cont = Console.ReadLine().ToUpper();
                    if (cont == "Y")
                    {
                        MakeAChoice();
                    }
                    else if (cont == "N")
                    {
                        Environment.Exit(0);
                    }
                    else if (cont != "Y" || cont != "N")
                    {
                        Red();
                        Console.WriteLine("Invalid choice.  Please choose either 'Y' or 'N' from the keybord." );
                        Console.ResetColor();
                    }
                }
                Console.ResetColor();
            }
            static void Green()
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            static void Red()
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}
