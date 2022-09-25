namespace MarsRover.Model
{
    public class Plateau
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}

