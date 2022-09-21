using System;
using System.Text.RegularExpressions;
using MarsRover.Model;

namespace MarsRover.Validator
{
    public class MarsRoverValidator
    {
        private int minimumLowerBoundary = 0;
        private const string directionRegEx = "N|E|S|W";

        public MarsRoverValidator()
        {
        }

        public void ValidatePosition(string positionInput)
        {
            var roverPosition = positionInput.Trim().Split(" ");
            if (Convert.ToInt32(roverPosition[0]) < minimumLowerBoundary || Convert.ToInt32(roverPosition[1]) < minimumLowerBoundary ||
                !Regex.IsMatch(roverPosition[2].ToString(), directionRegEx))
            {
                throw new ArgumentException("Position can not have negative values or invalid direction.");
            }
        }

        public void ValidatePlateau(string plateauInput)
        {
            var plateauDimensions = Array.ConvertAll(plateauInput.Trim().Split(" "), x => Convert.ToInt32(x));
            if (plateauDimensions[0] < minimumLowerBoundary || plateauDimensions[1] < minimumLowerBoundary)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
        }

        public void ValidateInitialPosition(string positionInput, Plateau plateau)
        {
            if (plateau is null)
            {
                throw new NullReferenceException("Rover can not be created without a plateau.");
            }

            var roverPosition = positionInput.Trim().Split(" ");
            if (Convert.ToInt32(roverPosition[0]) > plateau.Width || Convert.ToInt32(roverPosition[1]) > plateau.Height)
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
        }
    }
}

