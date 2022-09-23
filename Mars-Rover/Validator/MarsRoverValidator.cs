using System;
using System.Text.RegularExpressions;
using MarsRover.Exceptions;
using MarsRover.Model;

namespace MarsRover.Validator
{
    public class MarsRoverValidator
    {
        private int minimumLowerBoundary = 0;
        private const string directionRegEx = "N|E|S|W";
        private const string movementRegEx = "^[LRM]*$";

        public MarsRoverValidator()
        {
        }

        public void ValidatePosition(string positionInput)
        {
            var roverPosition = positionInput.Trim().Split(" ");
            if (Convert.ToInt32(roverPosition[0]) < minimumLowerBoundary || Convert.ToInt32(roverPosition[1]) < minimumLowerBoundary ||
                !Regex.IsMatch(roverPosition[2].ToString(), directionRegEx))
            {
                throw new PositionException("Position can not have negative values or invalid direction.");
            }
        }

        public void ValidatePlateau(string plateauInput)
        {
            int [] plateauDimensions;
            try
            {
                plateauDimensions = Array.ConvertAll(plateauInput.Trim().Split(" "), x => Convert.ToInt32(x));
            }
            catch (Exception ex)
            {
                throw new PlateauException("Plateau can not be created with invalid input.");
            }
            
            if (plateauDimensions[0] < minimumLowerBoundary || plateauDimensions[1] < minimumLowerBoundary)
            {
                throw new PlateauException("Plateau can not be created with negative values.");
            }
        }

        public void ValidateInitialPosition(string positionInput, Plateau plateau)
        {
            if (plateau is null)
            {
                throw new NullReferenceException("Rover can not be created without a Plateau.");
            }

            var roverPosition = positionInput.Trim().Split(" ");
            if (Convert.ToInt32(roverPosition[0]) > plateau.Width || Convert.ToInt32(roverPosition[1]) > plateau.Height)
            {
                throw new PositionException("Rover can not be placed outside the Plateau dimension.");
            }
        }

        public void ValidateMoveInstructions(string moveInstructions)
        {
            if (!Regex.IsMatch(moveInstructions, movementRegEx))
            {
                throw new MoveException("Not a valid movement - move aborted.");
            }
        }

        public void ValidateMovePosition(Rover rover, Plateau plateau)
        {
            if (rover.CurrentPosition.XPosition > plateau.Width || rover.CurrentPosition.YPosition > plateau.Height)
            {
                throw new MoveException("Move instructions takes Rover outside of Plateau - move aborted.");
            }
        }
    }
}

