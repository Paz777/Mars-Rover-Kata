using System;
using System.Text.RegularExpressions;

namespace MarsRover.Model
{
    public class Position
    {
        public int XPosition {get; set;}
        public int YPosition { get; set; }
        public char Direction { get; set; }

        public Position(int xPosition, int yPosition, char direction)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Direction = direction;
        }
    }
}

