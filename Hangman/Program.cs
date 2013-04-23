using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();
            game.Start();
        }
    }
}
