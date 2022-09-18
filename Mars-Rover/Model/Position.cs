using System;
using System.Text.RegularExpressions;

namespace MarsRover.Model
{
    public class Position
    {
        public int XPosition {get; private set;}
        public int YPosition { get; private set; }
        public char Direction { get; set; }
        private int minXPosition = 0;
        private int minYPosition = 0;

        private const string directionRegEx = "N|E|S|W";

        public Position(int xPosition, int yPosition, char direction)
        {
            if (xPosition < minXPosition || yPosition < minYPosition || !Regex.IsMatch(direction.ToString(), directionRegEx))
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

