using System;
using System.Text.RegularExpressions;

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
    }
}

