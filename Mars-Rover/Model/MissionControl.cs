using System;
using System.Text.RegularExpressions;
using MarsRover.Validator;

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
        private const string movementRegEx = "^[LRM]*$";
        private MarsRoverValidator validator;

        public MissionControl()
        {
            validator = new MarsRoverValidator();
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
            if (plateau is null)
            {
                throw new NullReferenceException("Rover can not be created without a plateau.");
            }
            validator.ValidatePosition(input);
            if (Convert.ToInt32(roverPosition[0]) > plateau.Width || Convert.ToInt32(roverPosition[1]) > plateau.Height)
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
            rover = new Rover(new Position(Convert.ToInt32(roverPosition[0]),
                Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));
        }

        public void MoveRover(string movement)
        {
            if (!Regex.IsMatch(movement, movementRegEx))
            {
                throw new ArgumentException("Not a valid movement move aborted.");
            }
            char[] moveInstructions = movement.ToCharArray();
            foreach (char move in moveInstructions)
            {
                if (move == 'L')
                {
                    rover.SpinLeft();
                }
                else if (move == 'R')
                {
                    rover.SpinRight();
                }
                else if (move  == 'M')
                {
                    rover.Move();
                }
            }
        }
    }
}