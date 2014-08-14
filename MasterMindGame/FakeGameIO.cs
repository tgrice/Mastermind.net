using System.Collections.Generic;

namespace MasterMindGame
{
    public class FakeGameIO : IGameIO
    {
        public string GetUserGuess()
        {
            return "1111";
        }

        private string Prompt(string value)
        {
            return value;
        }

        public void PrintBoard(System.Collections.Generic.List<System.Collections.Generic.List<int>> guesses, System.Collections.Generic.List<string> feedbacks)
        {
            
        }

        public void PrintLoseGame(string value, List<int> code)
        {
            
        }

        public void PrintLine(string value)
        {
             
        }


        public string GameSetUp()
        {
            return "7";
        }


        public string GetPlayAgainResponse()
        {
            return "N";
        }


        void IGameIO.GameSetUp()
        {
            
        }

        public string GetTurnLimit()
        {
            return "7";
        }

        public int GetCodeLength()
        {
            return 4;
        }
    }
}
