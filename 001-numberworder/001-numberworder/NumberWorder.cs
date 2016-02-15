using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_numberworder
{
    public class NumberWorder
    {
        private readonly string _userInput;
        private string output;
        private readonly string[] _words = {"ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE"};
  
        public NumberWorder(string numbers)
        {
            _userInput = numbers;
            Translate();
        }

        private void Translate()
        {
            foreach (char c in _userInput)
            {
                var index = (int) Char.GetNumericValue(c);
                if (index > -1)
                {
                    output += _words[index];
                }
                else
                {
                    output += ">> \"" + c + "\" invalid character supplied. Integers only, please.";
                    return;
                }
            }
        }

        public string GetOutput()
        {
            return output;
        }
    }
}
