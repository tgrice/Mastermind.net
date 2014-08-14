using System;
using System.Collections.Generic;
using MasterMindGame;

namespace MasterMindConsole
{
    public class ConsoleIO : IGameIO
    {
        public void GameSetUp()
        {
            Console.Title = "MasterMind";
            PrintRules();
        }

        private void PrintRules()
        {
            Console.Clear();
            Console.WriteLine("Try to guess the code.\n\n" +
                              "Each digit is between 0-9.\n\n" +
                              "A 'B' in the feedback means that a number\n" +
                              "in the code is correct and in the correct position. \n\n" +
                              "A 'W' in the code means that a number\n" +
                              "in the code is correct but is in the wrong position. \n\n" +
                              "There can be multiple digits with the same number. \n\n" +
                              "Good Luck!!!\n");
        }

        public int GetCodeLength()
        {
            Console.Write("Please enter a code length between 4-10: ");
            var turnLimit = Convert.ToInt32(GetUserInputAsInt());
            while (turnLimit < 4 || turnLimit > 10)
            {
                Console.WriteLine("Invalid code length, please try again: ");
                turnLimit = Convert.ToInt32(GetUserInputAsInt());
            }
            return turnLimit;
        }

        private string GetUserInputAsInt()
        {
            var result = Console.ReadLine();
            long x; 
            while (!Int64.TryParse(result, out x) || result == null)
            {
                Console.WriteLine("Not a valid Number, Please Try Again: ");
                result = Console.ReadLine();
            }
            return result;
        }

        public string GetTurnLimit()
        {
            Console.Write("Please enter the number of desired turns: ");
            var turnLimit = GetUserInputAsInt();
            return GetValidTurnLimit(turnLimit);
        }

        private string GetValidTurnLimit(string turnLimit)
        {
            while (Convert.ToInt32(turnLimit) <= 0)
            {
                Console.Write("Invalid number of turns, please try again: ");
                turnLimit = GetUserInputAsInt();
            }
            return turnLimit;
        }

        public void PrintBoard(List<List<int>> guesses, List<string> feedbacks)
        {
            Console.Clear();
            Console.WriteLine("| Guess     | Feedback  |");
            WriteLines(guesses, feedbacks);
        }

        private void WriteLines(List<List<int>> guesses, List<string> feedbacks)
        {
            for (var i = 0; i < guesses.Count; i++)
            {
                var guess = guesses[i];
                Console.Write("| ");
                PrintListOfInts(guess);
                Console.Write("| ");
                var feedback = feedbacks[i];
                PrintFeedbackString(feedback);
                Console.WriteLine("|");
            }
        }

        private static void PrintListOfInts(List<int> list)
        {
            var addedSpaces = 10 - list.Count;
            foreach (var g in list)
                Console.Write(g);
            PrintSpaces(addedSpaces);
        }

        private static void PrintSpaces(int addedSpaces)
        {
            for (var i = 0; i < addedSpaces; i++)
                Console.Write(" ");
        }

        private static void PrintFeedbackString(string feedback)
        {
            var addedSpaces = 10 - feedback.Length;
            Console.Write(feedback);
            PrintSpaces(addedSpaces);
        }

        public string GetUserGuess()
        {
            Console.Write("Enter Guess: ");
            return GetUserInputAsInt();
        }

        public void PrintLine(string value)
        {
            Console.WriteLine(value);
        }

        public void PrintLoseGame(string value, List<int> code)
        {
            Console.Write(value);
            Console.Write(" ");
            PrintListOfInts(code);
            Console.WriteLine();
        }

        public string GetPlayAgainResponse()
        {
            Console.WriteLine("Would you like to play again? (Y/N): ");
            var response = Console.ReadLine();
            while (response.ToUpper() != "Y" && response.ToUpper() != "N")
            {
                Console.Write("Invalid response, please try again: ");
                response = Console.ReadLine();
            }
            return response.ToUpper();
        }
    }
}