using System;
using System.Collections.Generic;
using System.Linq;

namespace _1st_Question__Hangman_
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Please Select Menu :");
            string decision = Console.ReadLine();
            Console.Clear();

            if (decision == "1")
            {
                int score = 0;
                char vibeCheck;
                HangmanWords hangmanWords = new HangmanWords();
                string chosenWord = hangmanWords.ChoosingWord();
                int lenght = chosenWord.Length;


                char[] InUseWord = chosenWord.ToCharArray();
                char[] blind = new char[lenght];
                for (int blindCount = 0; blindCount < chosenWord.Length; blindCount++)
                {
                    blind[blindCount] = Char.Parse("_");
                }



                Console.WriteLine("Play Game Hangman");
                Console.WriteLine("----------------------------------------");


                do
                {
                    Console.WriteLine("Incorrect Score: {0}", score);
                    for (int wordCount = 0; wordCount < InUseWord.Length; wordCount++)
                    {
                        Console.Write(blind[wordCount] + " ");
                    }

                    Console.WriteLine("");
                    Console.Write("Input letter alphabet: ");
                    string previbecheck = Console.ReadLine();
                    vibeCheck = char.Parse(previbecheck);

                    if (Array.Exists(InUseWord, element => element == (vibeCheck)) == true)
                    {
                        for (int indexfinding = 0; indexfinding < InUseWord.Length; indexfinding++)
                        {
                            int index = Array.IndexOf(InUseWord, vibeCheck, indexfinding);
                            if (index != -1)
                            {
                                blind[index] = InUseWord[index];
                            }
                        }
                    }
                    else
                    {
                        score++;

                    }
                    if (score == 6)
                    {
                        break;
                    }
                    Console.Clear();
                }
                while (Array.Exists(blind, element => element == Char.Parse("_")) == true);




                if (score < 6)
                {
                    Console.WriteLine("You Win");
                }

                if (score >= 6)
                {
                    Console.WriteLine("Game Over");
                }

            }
            else
            {
                Console.WriteLine("SEE YA!");
            }
        }
    }

    class HangmanWords
    {
        List<string> wordsList = new List<string>();

        public HangmanWords()
        {
            wordsList.Add("Tennis");
            wordsList.Add("Football");
            wordsList.Add("Badminton");

        }

        public string ChoosingWord()
        {
            Random random = new Random();
            int resultRandom = random.Next(1, 3);
            return wordsList[resultRandom];
        }

    }
}
