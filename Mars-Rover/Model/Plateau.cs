using System;
namespace MarsRover.Model
{
    public class Plateau
    {
        public Plateau(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
        }
    }
}

