using System;
using System.Collections.Generic;

namespace MasterMindGame
{
    public class GameController
    {
        private readonly ICodeComparer _codeComparer;
        private readonly IGuessTranslator _guessTranslate;
        private readonly IGameIO _consoleIO;
        private readonly ICodeCreator _builder;

        private int _turnLimit;
        private List<int> _code;
        private List<int> _guess;
        private string _feedback;
        private readonly List<List<int>> _guesses;
        private readonly List<string> _feedbacks;
        private const string WinString = "VICTORY!!";
        private const string LoseString = "Game Over, Turn Limit Reached.";
        private const string InvalidGuess = "Invalid length.";
        private const string ReplayString = "Y";

        public List<int> Code { get { return _code; } }
        public List<int> Guess { get { return _guess; } }
        public string Feedback { get { return _feedback; } }

        public GameController(ICodeCreator builder,  ICodeComparer comparer,  IGuessTranslator trans, IGameIO consoleIO)
        {
            _guessTranslate = trans;
            _codeComparer = comparer;
            _builder = builder;
            _consoleIO = consoleIO;
            _guesses = new List<List<int>>();
            _feedbacks = new List<string>();
        }

        public bool Run()
        {
            SetUpGameRules();
            while (!EndOfGame())
            {
                PrintGameBoard();
                GetUserGuess();
                GetFeedback();
                StoreGuessAndFeedback();
                if (IsWin(_guess, _code)) break;
            }
            VictoryOrLose();
            return IsPlayAgain();
        }

        private void SetUpGameRules()
        {
            _consoleIO.GameSetUp();
            SetCodeLength(_consoleIO.GetCodeLength());
            SetTurnLimit(_consoleIO.GetTurnLimit());
           
        }

        private void SetCodeLength(int desiredCodeLength)
        {
            _code = _builder.GenerateCode(desiredCodeLength);
        }

        private void SetTurnLimit(string desiredTurnNumber)
        {
            _turnLimit = Convert.ToInt32(desiredTurnNumber);
        }

        private bool EndOfGame()
        {
            return (_guesses.Count >= _turnLimit);
        }

        private void PrintGameBoard()
        {
            _consoleIO.PrintBoard(_guesses, _feedbacks);
        }

        private void GetUserGuess()
        {
            var attempt = _consoleIO.GetUserGuess();
            while (attempt.Length != _code.Count)
            {
                _consoleIO.PrintLine(InvalidGuess);
                attempt = _consoleIO.GetUserGuess();
            }
            _guess = _guessTranslate.Translate(attempt);
        }

        private void GetFeedback()
        {
            _feedback = _codeComparer.CompareCode(_guess, _code); 
        }

        private void StoreGuessAndFeedback()
        {
            _guesses.Add(_guess);
            _feedbacks.Add(_feedback);
        }

        private bool IsWin(List<int> guess, List<int> code)
        {
            var count = 0;
            for (var i = 0; i < code.Count; i++)
            {
                if (code[i] == guess[i])
                    count++;
            }
            if (count == code.Count)
            {
                _feedback = WinString;
                return true;
            }
            return false;
        }

        private void VictoryOrLose()
        {
            if (IsWin(_guess, _code))
                _consoleIO.PrintLine(WinString);
            else
            {
                _feedback = LoseString;
                _consoleIO.PrintLoseGame(_feedback, _code);
            }
        }

        private bool IsPlayAgain()
        {
            var response = _consoleIO.GetPlayAgainResponse();
            if (response == ReplayString)
                return true;
            return false;
        }
    }
}
