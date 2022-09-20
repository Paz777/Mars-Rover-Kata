using System;
using System.Text.RegularExpressions;

namespace MarsRover.Model
{
    public class MissionControl
    {
        public int GetPlateauWidth { get => plateau.Width; }
        public int GetPlateauHeight { get => plateau.Height; }
        public Position GetRoverPosition { get => rover.CurrentPosition; }

        private Plateau plateau;
        private Rover rover;
        private int minimumLowerBoundary = 0;
        private const string directionRegEx = "N|E|S|W";

        public MissionControl()
        {
        }

        public void AddPlateau(string input)
        {
            var dimensions = Array.ConvertAll(input.Trim().Split(" "), x => Convert.ToInt32(x));
            if (dimensions[0] < minimumLowerBoundary || dimensions[1] < minimumLowerBoundary)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
            plateau = new Plateau(dimensions[0], dimensions[1]);
        }

        public void AddRover(string input)
        {
            var roverPosition = input.Trim().Split(" ");
            if (Convert.ToInt32(roverPosition[0]) < minimumLowerBoundary || Convert.ToInt32(roverPosition[1]) < minimumLowerBoundary ||
                !Regex.IsMatch(roverPosition[2].ToString(), directionRegEx))
            {
                throw new ArgumentException("Position can not have negative values or invalid direction.");
            }
            if (Convert.ToInt32(roverPosition[0]) > plateau.Width || Convert.ToInt32(roverPosition[1]) > plateau.Height)
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
            rover = new Rover(plateau);
            rover.PlaceRoverOnPlateau(new Position(Convert.ToInt32(roverPosition[0]),
                Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));
        }
    }
}

