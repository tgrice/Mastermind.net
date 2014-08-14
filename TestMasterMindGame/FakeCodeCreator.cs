using System.Collections.Generic;
using MasterMindGame;

namespace TestMasterMindGame
{
    public class FakeCodeCreator: ICodeCreator
    {
        private List<int> _code;
        public FakeCodeCreator(List<int> code)
        {
            _code = code;
        }
        public List<int> GenerateCode(int codeLength)
        {
            return _code;
        }
    }
}
