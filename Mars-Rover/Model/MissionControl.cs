using System;
namespace MarsRover.Model
{
    public class MissionControl
    {
        private Plateau plateau;
        private Rover rover;

        public MissionControl()
        {
        }

        public int GetPlateauWidth { get => plateau.Width; }
        public int GetPlateauHeight { get => plateau.Height; }
        public Position GetRoverPosition { get => rover.CurrentPosition;}

        public void AddPlateau(string input)
        {
            var dimensions = Array.ConvertAll(input.Trim().Split(" "), x => Convert.ToInt32(x));
            plateau = new Plateau(dimensions[0], dimensions[1]);
        }

        public void AddRover(string input)
        {
            var roverPosition = input.Trim().Split(" ");
            rover = new Rover(plateau);
            rover.PlaceRoverOnPlateau(new Position(Convert.ToInt32(roverPosition[0]),
                Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));
        }
    }
}

