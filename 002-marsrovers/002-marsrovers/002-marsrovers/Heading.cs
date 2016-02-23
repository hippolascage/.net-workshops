using System.Collections.Generic;

namespace _002_marsrovers
{
    public class Heading
    {
        private readonly List<char> _headings = new List<char> { 'N', 'E', 'S', 'W'};
        private int _headingIndex;

        public Heading(char heading)
        {
            _headingIndex = _headings.IndexOf(heading);
        }

        public void TurnRight()
        {
            if (_headingIndex == 3)
            {
                _headingIndex = 0;
            }
            else
            {
                _headingIndex++;
            }
        }

        public void TurnLeft()
        {
            if (_headingIndex == 0)
            {
                _headingIndex = 3;
            }
            else
            {
                _headingIndex--;
            }
        }

        public char GetHeading()
        {
            return _headings[_headingIndex];
        }

        public void SetHeading(char heading)
        {
            _headingIndex = _headings.IndexOf(heading);
        }
    }
}
