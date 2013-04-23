using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        private const char placeHolderChar = '_';
        private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string exactWord = "HORSEE";
        private static List<char> guessedLetters = new List<char>();
        private static List<char> guessedWord = new List<char>(new string(placeHolderChar, exactWord.Length));
        private static int lives = 5;
        private static ConsoleColor warningColor = ConsoleColor.Yellow;
        private static ConsoleColor errorColor = ConsoleColor.Red;
        private static ConsoleColor successColor = ConsoleColor.Green;
        private static ConsoleColor infoColor = ConsoleColor.Gray;

        private static bool UserHasLives()
        {
            return lives > 0;
        }
        
        private static void DisplayStatus() 
        {
            Console.WriteLine();
            Console.WriteLine("Lives: {0}", lives);
            Console.Write("Word: ");
        }

        private static void DisplayGuessedWord()
        {
            foreach (char letter in guessedWord)
            {
                Console.Write("{0} ", letter);
            }

            Console.WriteLine();
            Console.WriteLine("Guest a letter: ");
        }

        private static char CaptureUserKey()
        {
            char input = Console.ReadKey().KeyChar;
            input = char.ToUpper(input);
            return input;
        }

        private static void ClearConsole()
        {
            Console.WriteLine();
            Console.Clear();
        }

        private static void DisplayInvalidInput()
        {
            DisplayMessage(errorColor, "Invalid input! Expected a letter. \n");
        }

        private static void DisplayRepeatedLetterError(char input)
        {
            DisplayMessage(errorColor, "Oops! You've already chosen \"{0}\"", input);
        }

        private static void DisplayCongrats()
        {
            DisplayMessage(successColor, "Great Guess! \n");
        }

        private static bool IsLetter(char input)
        {
            return alphabet.Contains(input.ToString());
        }

        private static bool LetterAlreadyGuessed(char input)
        {
            return guessedLetters.Contains(input);
        }

        private static bool WordHasLetter(char input)
        {
            return exactWord.Contains(input.ToString());
        }
        
        private static void SetGuessedLetter(char input)
        {
            for (int i = 0; i < exactWord.Length; i++)
            {
                if (exactWord[i].Equals(input))
                {
                    guessedWord[i] = input;
                }
            }
        }

        private static void DecrementLives()
        {
            DisplayMessage(warningColor, "Wrong!\n");
            lives--;
        }

        private static void DisplayUserHasWon()
        {
            DisplayMessage(successColor, "You win! \n");
            DisplayWord();
        }

        private static bool WordGuessed()
        {
            return !guessedWord.Contains(placeHolderChar);
        }

        private static void DisplayWord()
        {
            DisplayMessage(infoColor, "The word was: ");
            DisplayMessage(WordGuessed() ? successColor : errorColor, exactWord);
        }

        private static void DisplayGameOver()
        {
            DisplayMessage(errorColor, "Game Over! You lose, play again.\n");
            DisplayWord();
        }

        private static void DisplayMessage(ConsoleColor color, string message, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.Write(message, args);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");

            // while user still has lives
            while (UserHasLives())
            {
                DisplayStatus();

                // print each letter of guessed word
                DisplayGuessedWord();

                // wait for user to press a key and capture the key pressed
                char input = CaptureUserKey();

                // once the user has given input, lets assume the screen needs "refreshed" and clear it
                ClearConsole();

                // if user input is not a letter
                if (!IsLetter(input))
                {
                    DisplayInvalidInput();
                    continue;
                }

                // if user has already guessed the letter
                if (LetterAlreadyGuessed(input))
                {
                    DisplayRepeatedLetterError(input);
                    continue;
                }

                guessedLetters.Add(input);

                // if user enters correct letter, set that letter at that index
                if (WordHasLetter(input))
                {
                    DisplayCongrats();
                    SetGuessedLetter(input);
                    if (WordGuessed())
                    {
                        DisplayUserHasWon();
                        break;
                    }
                }
                else
                {
                    DecrementLives();

                    if (!UserHasLives())
                    {
                        DisplayGameOver();
                    }
                }
            }

            Console.WriteLine("\nThank you for playing!");
            Console.ReadKey();
        }
    }
}