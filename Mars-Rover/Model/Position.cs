using System;
namespace MarsRover.Model
{
    public class Position
    {
        public int X {get; private set;}
        public int Y { get; private set; }
        public char Direction { get; private set; }

        public Position(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}

