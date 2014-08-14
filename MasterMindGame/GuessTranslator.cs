using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterMindGame
{
    public class GuessTranslator : IGuessTranslator
    {
        public List<int> Translate(string guess)
        {
            return guess.Select(x=> 
                Convert.ToInt32(x.ToString(CultureInfo.InvariantCulture)))
                    .ToList();
        }
    }
}
