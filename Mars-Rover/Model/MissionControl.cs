﻿using System;
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
        private const string movementRegEx = "^[LRM]*$";
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