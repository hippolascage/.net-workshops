using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace _002_marsrovers
{
    public class Heading
    {
        private enum Headings {N, E, W, S};
        private char CurrentHeading { get; set; }
        private Dictionary<char, char> RightTurns = new Dictionary<char, char>()
        {
            { 'N', 'E' },
            { 'S', 'W' },
            { 'E', 'S' },
            { 'W', 'N' }
        };
        private Dictionary<char, char> LeftTurns = new Dictionary<char, char>()
        {
            { 'N', 'W' },
            { 'S', 'E' },
            { 'E', 'N' },
            { 'W', 'S' }
        };

        public Heading(char heading)
        {
            CurrentHeading = heading;
        }

        public void TurnRight()
        {
            CurrentHeading = RightTurns[CurrentHeading];
        }

        public void TurnLeft()
        {
            CurrentHeading = LeftTurns[CurrentHeading];
        }

        public char GetHeading()
        {
            return CurrentHeading;
        }

        public void SetHeading(char heading)
        {
            CurrentHeading = heading;
        }
    }
}
