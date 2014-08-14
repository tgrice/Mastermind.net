using System.Collections.Generic;

namespace MasterMindGame
{
    public interface IGuessTranslator
    {
        List<int> Translate(string guess);
    }
}