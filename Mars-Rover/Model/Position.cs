using System;
using System.Text.RegularExpressions;

namespace MarsRover.Model
{
    public class Position
    {
        public int XPosition;
        public int YPosition;
        public char Direction;

        public Position(int xPosition, int yPosition, char direction)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Direction = direction;
        }
    }
}

