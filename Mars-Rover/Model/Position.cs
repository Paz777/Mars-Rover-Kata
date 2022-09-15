using System;
using System.Text.RegularExpressions;

namespace MarsRover.Model
{
    public class Position
    {
        public int X {get; private set;}
        public int Y { get; private set; }
        public char Direction { get; private set; }

        private const string directionRegEx = "N|E|S|W";

        public Position(int x, int y, char direction)
        {
            if (x < 0 || y < 0 || !Regex.IsMatch(direction.ToString(), directionRegEx))
            {
                throw new ArgumentException("Position can not have negative values or invalid direction.");
            }
            else
            {
                X = x;
                Y = y;
                Direction = direction;
            }
        }
    }
}

