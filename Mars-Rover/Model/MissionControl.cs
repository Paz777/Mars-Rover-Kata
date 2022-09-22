using System;
using System.Text.RegularExpressions;
using MarsRover.Exceptions;
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
        private MarsRoverValidator validator;

        public MissionControl()
        {
            validator = new MarsRoverValidator();
        }

        public void AddPlateau(string input)
        {
            validator.ValidatePlateau(input);

            var plateauDimensions = Array.ConvertAll(input.Trim().Split(" "), x => Convert.ToInt32(x));
            plateau = new Plateau(plateauDimensions[0], plateauDimensions[1]);
        }

        public void AddRover(string input)
        {
            validator.ValidatePosition(input);
            validator.ValidateInitialPosition(input, plateau);

            var roverPosition = input.Trim().Split(" ");
            rover = new Rover(new Position(Convert.ToInt32(roverPosition[0]),
                Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));
        }

        public void MoveRover(string moveInstructions)
        {
            validator.ValidateMoveInstructions(moveInstructions);

            Position positionBeforeMove = new Position(rover.CurrentPosition.XPosition, rover.CurrentPosition.YPosition,
                rover.CurrentPosition.Direction);

            char[] instructions = moveInstructions.ToCharArray();
            foreach (char move in instructions)
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

            try
            {
                validator.ValidateMovePosition(rover, plateau);
            }
            catch (MoveException ex)
            {
                this.rover.CurrentPosition = positionBeforeMove;
                throw ex;
            }
        }
    }
}