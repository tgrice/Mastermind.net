using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MasterMindGame
{
    public interface IGameIO
    {
        string GetUserGuess();
        void PrintLine(string value);
        void PrintBoard(List<List<int>> guesses, List<string> feedbacks);
        void PrintLoseGame(string value, List<int> code);
        void GameSetUp();
        string GetTurnLimit();
        int GetCodeLength();
        string GetPlayAgainResponse();
    }
}
