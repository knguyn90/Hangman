using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            const char placeHolderChar = '_';
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string exactWord = "HORSEE";
            List<char> guessedLetters = new List<char>();
            List<char> guessedWord = new List<char>(new string(placeHolderChar, exactWord.Length));
            int lives = 5;
            ConsoleColor warningColor = ConsoleColor.Yellow;
            ConsoleColor errorColor = ConsoleColor.Red;
            ConsoleColor successColor = ConsoleColor.Green;

            Console.WriteLine("Welcome to Hangman!");

            // while user still has lives
            while (lives > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Lives: {0}", lives);
                Console.Write("Word: ");

                // print each letter of guessed word
                foreach (char letter in guessedWord)
                {
                    Console.Write("{0} ", letter);
                }

                Console.WriteLine();
                Console.WriteLine("Guest a letter: ");

                // wait for user to press a key and capture the key pressed
                char input = Console.ReadKey().KeyChar;
                input = char.ToUpper(input);

                // once the user has given input, lets assume the screen needs "refreshed" and clear it
                Console.WriteLine();
                Console.Clear();

                // if user input is not a letter
                if (!alphabet.Contains(input.ToString()))
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Invalid input! Expected a letter");
                    Console.ResetColor();
                    continue;
                }

                // if user has already guessed the letter
                if (guessedLetters.Contains(input))
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Oops! You've already chosen \"{0}\"", input);
                    Console.ResetColor();
                    continue;
                }

                guessedLetters.Add(input);

                // if user enters correct letter, set that letter at that index

                if (exactWord.Contains(input.ToString()))
                {
                    Console.ForegroundColor = successColor;
                    Console.WriteLine("Great Guess!");
                    Console.ResetColor();
                    for (int i = 0; i < exactWord.Length; i++)
                    {
                        if (exactWord[i].Equals(input))
                        {
                            guessedWord[i] = input;
                        }
                    }
                    //bool hasWon = true;
                    //for (int i = 0; i < exactWord.Length; i++)
                    //{
                    //    if (exactWord[i] != guessedWord[i])
                    //    {
                    //        hasWon = false;
                    //        break;
                    //    }
                    //}

                    //if (hasWon)
                    //{

                    //    break;
                    //}
                    // OR
                    // Alternative
                    if (!guessedWord.Contains(placeHolderChar))
                    {
                        Console.ForegroundColor = successColor;
                        Console.WriteLine("You win!");
                        Console.ResetColor();
                        Console.Write("The word was: ");
                        Console.ForegroundColor = successColor;
                        Console.WriteLine(exactWord);
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = warningColor;
                    Console.WriteLine("Wrong!");
                    Console.ResetColor();
                    lives--;

                    if (lives == 0)
                    {
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine("Game Over! You lose, play again.");
                        Console.ResetColor();
                        Console.Write("The word was: ");
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine(exactWord);
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
        }
    }
}