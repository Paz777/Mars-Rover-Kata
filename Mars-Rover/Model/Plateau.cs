using System;
namespace MarsRover.Model
{
    public class Plateau
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private int minPlateauVal = 0;

        public Plateau(int width, int height)
        {
            if (width < minPlateauVal || height < minPlateauVal)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
            Width = width;
            Height = height;
        }
    }
}

