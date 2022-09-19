using System;
using System.Text.RegularExpressions;

namespace MarsRover.Model
{
    public class Position
    {
        public int XPosition {get; set;}
        public int YPosition { get; set; }
        public char Direction { get; set; }

        private int minPosition = 0;

        private const string directionRegEx = "N|E|S|W";

        public Position(int xPosition, int yPosition, char direction)
        {
            if (xPosition < minPosition || yPosition < minPosition || !Regex.IsMatch(direction.ToString(), directionRegEx))
            {
                throw new ArgumentException("Position can not have negative values or invalid direction.");
            }
            else
            {
                XPosition = xPosition;
                YPosition = yPosition;
                Direction = direction;
            }
        }
    }
}

