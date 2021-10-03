using System;
using System.Collections.Generic;
using System.Linq;

namespace _1st_Question__Hangman_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main Menu, Nothing out of ordinary
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Please Select Menu :");
            string decision = Console.ReadLine();
            
            //Yours Truly Wiping System
            Console.Clear();

            //Start Playing game
            if (decision == "1")
            {
                //Score for keeping track of failure
                int score = 0;
                //For checking if the player's chosen word is worth enough the success, or disappointingly failure
                char vibeCheck;
                //Adding Words in Hangman game
                HangmanWords hangmanWords = new HangmanWords();
                //Using method to choosing random word
                string chosenWord = hangmanWords.ChoosingWord();
                //Size check for reference
                int lenght = chosenWord.Length;

                //Turn them to array for easing the pain to find the index
                char[] InUseWord = chosenWord.ToCharArray();
                //Blind is for showing the progress of player or the stillness of their progress
                char[] blind = new char[lenght];
                //Blindcounting to make sure that '_' will be just tad right amount
                for (int blindCount = 0; blindCount < chosenWord.Length; blindCount++)
                {
                    blind[blindCount] = Char.Parse("_");
                }


                //And Now thee game begin
                Console.WriteLine("Play Game Hangman");
                Console.WriteLine("----------------------------------------");

                //The main gameplay literal loop
                do
                {
                    //keep tracking of score every renewal of the loop
                    Console.WriteLine("Incorrect Score: {0}", score);
                    //And the blindcounting begin
                    for (int wordCount = 0; wordCount < InUseWord.Length; wordCount++)
                    {
                        Console.Write(blind[wordCount] + " ");
                    }

                    //A blankness for decorating and dramatic purpose
                    Console.WriteLine("");
                    //The first choice, always the toughtest for both easy-going and foolhardy alike
                    Console.Write("Input letter alphabet: ");
                    //Preparing for vibe check
                    string previbecheck = Console.ReadLine();
                    //Vibe check engage
                    vibeCheck = char.Parse(previbecheck);

                    //Digressing the vibe check to show thier success
                    if (Array.Exists(InUseWord, element => element == (vibeCheck)) == true)
                    {
                        //using index for blind-openning section
                        for (int indexfinding = 0; indexfinding < InUseWord.Length; indexfinding++)
                        {
                            //Finding index for blind-openning
                            int index = Array.IndexOf(InUseWord, vibeCheck, indexfinding);
                            //If you don't account the possible negative that they can't find the char in some index, it'll crash, speaking from 4 hrs of experience
                            if (index != -1)
                            {
                                blind[index] = InUseWord[index];
                            }
                        }
                    }

                    //And for the failure, a step of doom for them
                    else
                    {
                        score++;

                    }

                    //Steps and far and it'll literally and figuratively break
                    if (score == 6)
                    {
                        break;
                    }
                    //for clean game end screen
                    Console.Clear();
                }
                //To validate that it won't go wrong
                while (Array.Exists(blind, element => element == Char.Parse("_")) == true);



                //Some win, some lose, simple as that
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

    //Classing them out for managing
    class HangmanWords
    {
        //Using list here for ease in indexing
        List<string> wordsList = new List<string>();

        //Preparing the prepared words
        public HangmanWords()
        {
            wordsList.Add("Tennis");
            wordsList.Add("Football");
            wordsList.Add("Badminton");

        }

        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        //RNG JESUS GUIDE ME THE ROLL
        public string ChoosingWord()
        {
            Random random = new Random();
            int resultRandom = random.Next(1, 3);
            return wordsList[resultRandom];
        }

    }
}
