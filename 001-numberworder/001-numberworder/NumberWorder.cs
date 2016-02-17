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
        private readonly Dictionary<int, string> _words = new Dictionary<int, string>()
        {
            {1, "ONE"},
            {2, "TWO"},
            {3, "THREE" },
            {4, "FOUR" },
            {5, "FIVE" },
            {6, "SIX" },
            {7, "SEVEN" },
            {8, "EIGHT" },
            {9, "NINE" }
        };

        public NumberWorder(string numbers)
        {
            _userInput = numbers;
            Translate();
        }

        private void Translate()
        {

            var inputChars = _userInput.ToCharArray();
            output = _userInput.Aggregate("", (current, next) =>
            {
                int index;
                var isInt = int.TryParse(next.ToString(), out index);
                if (isInt)
                {
                    return current + _words[index];
                }
                else
                {
                    return current + ">> \"" + next + "\" invalid character supplied. Integers only, please.<<";
                }
            });
        }

        public string GetOutput()
        {
            return output;
        }
    }
}
