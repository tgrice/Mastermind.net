using System.Collections.Generic;

namespace MasterMindGame
{
    public interface ICodeCreator
    {
        List<int> GenerateCode(int codeLength);
    }
}