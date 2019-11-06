using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace teeest
{


    class Program
    {



        static Random rand;
        static string CurrentWord;
        static int CurrentWordLength;
        static int CurrentLives;
        static List<char> GuessedChars = new List<char>();
        static List<string> WordList = new List<string>()

        { 
            "aaaaam",
            "absurd",
            "abyss",
            "affix",
            "askew",
            "avenue",
            "awkward",
        };
        static void Main(string[] args)
        {

            rand = new Random();
            StartGame();
        }

        static void StartGame()
        {
            CurrentLives = 6;
            CurrentWord = WordList[rand.Next(WordList.Count() - 1)];
            CurrentWordLength = CurrentWord.Length;

            Console.WriteLine("Welcome To Hangman!\nThe Rules are pretty simple. The program will pick a random word and you will try to guess it one letter at a time.\nIf you are correct, then it will fill show you all instances of that letter in the word.\nIf you are incorrect, you will lose a life.\nBe careful! You only have 6 lives. If your lives reaches 0 the game will restart with a new word!\n\n\n");
            DrawScreen();
        }

        static void DrawScreen()
        {
            Console.WriteLine("Current Lives: " + CurrentLives + "\n");
            int drawnLength = 0;
            string winning = "";
            for (int i = 0; i < CurrentWordLength; i++)
            {
                if (GuessedChars.Any())
                {
                    if (GuessedChars.Contains(CurrentWord[i]))
                    {
                        Console.Write(CurrentWord[i].ToString() + " ");
                        winning += CurrentWord[i].ToString();
                        if (winning == CurrentWord)
                        {
                            Win();
                            return;
                        }
                    }
                    else
                        Console.Write("_ ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine("\n\n");
            Console.Write("Guess a letter: ");
            char guess = Char.ToLower(Console.ReadKey().KeyChar);
            CheckGuess(guess);
        }

        static void CheckGuess(char guess)
        {
            Console.WriteLine();
            bool guessedOne = false;
            for (int i = 0; i < CurrentWordLength; i++)
            {
                if (CurrentWord[i] == guess)
                {
                    guessedOne = true;
                    GuessedChars.Add(CurrentWord[i]);
                }
            }

            if (guessedOne == false)
                --CurrentLives;

            if (CurrentLives <= 0)
                Restart();

            DrawScreen();
        }

        static void Restart()
        {
            Console.WriteLine("Sorry, you lose! Would you like to play again? Y/N");
            char answer = Console.ReadKey().KeyChar;

            if (Char.ToLower(answer) == 'y')
            {
                StartGame();
            }
        }

        static void Win()
        {
            Console.WriteLine("\n\nCongratulations! You Win! Would you like to play again? Y/N");
            char answer = Console.ReadKey().KeyChar;

            if (Char.ToLower(answer) == 'y')
            {
                StartGame();
            }
            ////Console.WriteLine("Enter");
            ////string entered = Console.ReadLine();
            ////string underScore = string.Empty;
            ////for (int length = 0; length < entered.Length; length++)
            ////{
            ////  underScore = underScore + "_";
            //////}
            ////Console.WriteLine(underScore);
            ////Console.ReadKey(true);
            //Console.WriteLine("Welcome to Hangman, Let's Play.");
            //Console.WriteLine("");
            //Console.WriteLine("Please Type Your Secret Word");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.ReadLine();

            //for (int i = 0; i < (secretWord.Length); i++)
            //{
            //    secretWord.Replace(secretWord, ("_"));
            //    Console.ReadLine();




        }
    }
}
