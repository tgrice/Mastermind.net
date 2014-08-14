using System.Collections.Generic;
using System.Linq;

namespace MasterMindGame
{
    public class CodeComparer : ICodeComparer
    {
        private const string CorrectValueAndPosition = "B";
        private const string CorrectValueWrongPosition = "W";
        private string _feedback;

        

        public string CompareCode(List<int> guess, List<int> code)
        {
            _feedback = "";
            var testGuess = guess.ToList();
            var testCode = code.ToList();
            BuildFeedback(testGuess, testCode);
            return _feedback;
        }

        private void BuildFeedback(List<int> testGuess, List<int> testCode)
        {
            for (var i = 0; i < testCode.Count; i++)
            {
                if (IsDigitsEqual(testGuess, testCode, i))
                    AddBtoFeedback(testGuess, testCode, i);
            }
            for (var i = 0; i < testCode.Count; i++)
            {
                if (IsDigitInCode(testGuess, testCode, i))
                    AddWtoFeedback(testGuess, testCode, i);
            }
        }

        private static bool IsDigitsEqual(List<int> testGuess, List<int> testCode, int i)
        {
            return testGuess[i] == testCode[i];
        }

        private static bool IsDigitInCode(List<int> testGuess, List<int> testCode, int i)
        {
            return testCode.Contains(testGuess[i]);
        }

        private void AddBtoFeedback(List<int> testGuess, List<int> testCode, int i)
        {
            _feedback += CorrectValueAndPosition;
            testCode[i] = 12;
            testGuess[i] = 11;
        }

        private void AddWtoFeedback(List<int> testGuess, List<int> testCode, int i)
        {
            _feedback += CorrectValueWrongPosition;
            testCode[testCode.IndexOf(testGuess[i])] = 12;
            testGuess[i] = 11;
        }
    }
}
