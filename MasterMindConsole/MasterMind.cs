using System;
using MasterMindGame;

namespace MasterMindConsole
{
    public class MasterMind
    {
        public static void Main()
        {
            var runGame = true;
            while (runGame)
            {
                var gameController = new GameController(
                    new CodeCreator(),
                    new CodeComparer(),
                    new GuessTranslator(),
                    new ConsoleIO());
                runGame = gameController.Run();
            }
        }
    }
}
