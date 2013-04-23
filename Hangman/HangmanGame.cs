using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class HangmanGame
    {
        private const char placeHolderChar = '_';
        private const ConsoleColor warningColor = ConsoleColor.Yellow;
        private const ConsoleColor errorColor = ConsoleColor.Red;
        private const ConsoleColor successColor = ConsoleColor.Green;
        private const ConsoleColor infoColor = ConsoleColor.Gray;

        private string alphabet;
        private string exactWord;
        private List<char> guessedLetters;
        private List<char> guessedWord;
        private int lives;

        public HangmanGame()
        {
            alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            exactWord = "HORSEE";
            guessedLetters = new List<char>();
            guessedWord = new List<char>(new string(placeHolderChar, exactWord.Length));
            lives = 5;
        }

        private bool UserHasLives()
        {
            return lives > 0;
        }

        private void DisplayStatus()
        {
            Console.WriteLine();
            Console.WriteLine("Lives: {0}", lives);
            Console.Write("Word: ");
        }

        private void DisplayGuessedWord()
        {
            foreach (char letter in guessedWord)
            {
                Console.Write("{0} ", letter);
            }

            Console.WriteLine();
            Console.WriteLine("Guest a letter: ");
        }

        private char CaptureUserKey()
        {
            char input = Console.ReadKey().KeyChar;
            input = char.ToUpper(input);
            return input;
        }

        private void ClearConsole()
        {
            Console.WriteLine();
            Console.Clear();
        }

        private void DisplayInvalidInput()
        {
            DisplayMessage(errorColor, "Invalid input! Expected a letter. \n");
        }

        private void DisplayRepeatedLetterError(char input)
        {
            DisplayMessage(errorColor, "Oops! You've already chosen \"{0}\"", input);
        }

        private void DisplayCongrats()
        {
            DisplayMessage(successColor, "Great Guess! \n");
        }

        private bool IsLetter(char input)
        {
            return alphabet.Contains(input.ToString());
        }

        private bool LetterAlreadyGuessed(char input)
        {
            return guessedLetters.Contains(input);
        }

        private bool WordHasLetter(char input)
        {
            return exactWord.Contains(input.ToString());
        }

        private void SetGuessedLetter(char input)
        {
            for (int i = 0; i < exactWord.Length; i++)
            {
                if (exactWord[i].Equals(input))
                {
                    guessedWord[i] = input;
                }
            }
        }

        private void DecrementLives()
        {
            DisplayMessage(warningColor, "Wrong!\n");
            lives--;
        }

        private void DisplayUserHasWon()
        {
            DisplayMessage(successColor, "You win! \n");
            DisplayWord();
        }

        private bool WordGuessed()
        {
            return !guessedWord.Contains(placeHolderChar);
        }

        private void DisplayWord()
        {
            DisplayMessage(infoColor, "The word was: ");
            DisplayMessage(WordGuessed() ? successColor : errorColor, exactWord);
        }

        private void DisplayGameOver()
        {
            DisplayMessage(errorColor, "Game Over! You lose, play again.\n");
            DisplayWord();
        }

        private void DisplayMessage(ConsoleColor color, string message, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.Write(message, args);
            Console.ResetColor();
        }
        public void Start()
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
