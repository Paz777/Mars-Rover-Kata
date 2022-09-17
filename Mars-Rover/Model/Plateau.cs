using System;
namespace MarsRover.Model
{
    public class Plateau
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Plateau(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
            Width = x;
            Height = y;
        }
    }
}

