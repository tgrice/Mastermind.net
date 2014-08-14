using System;
using System.Collections.Generic;

namespace MasterMindGame
{
    public class CodeCreator : ICodeCreator
    {
        private List<int> _code;

        public CodeCreator()
        {
            _code = new List<int>();
        }

        public List<int> GenerateCode(int codeLength)
        {
            var rnd = new Random();
            for (var i = 0; i < codeLength; i++)
            {
                _code.Add(rnd.Next(10));
            }
            return _code;
        }
    }
}
