using System;
namespace MarsRover.Model
{
    public class MissionControl
    {
        private Plateau plateau;

        public MissionControl()
        {
        }

        public int GetPlateauWidth { get => plateau.Width; }
        public int GetPlateauHeight { get => plateau.Height; }

        public void AddPlateau(string input)
        {
            var dimensions = Array.ConvertAll(input.Trim().Split(" "), x => Convert.ToInt32(x));
            plateau = new Plateau(dimensions[0], dimensions[1]);
        }
    }
}

