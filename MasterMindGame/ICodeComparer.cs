using System.Collections.Generic;

namespace MasterMindGame
{
    public interface ICodeComparer
    {
        string CompareCode(List<int> guess, List<int> code);
    }
}
