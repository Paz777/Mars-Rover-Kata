using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using MarsRover.Exceptions;

namespace MarsRover.Model
{
    public class HungerGamesMissionControl : MissionControl
    {
        private Dictionary<string, BattleRover> roversDictionary = new Dictionary<string, BattleRover>();

        public HungerGamesMissionControl()
        {
        }

        public void AddRover(string name, string input)
        {
            validator.ValidatePosition(input);
            validator.ValidateInitialPosition(input, plateau);

            var roverPosition = input.Trim().Split(" ");
            var battleRover = new BattleRover(name, new Position(Convert.ToInt32(roverPosition[0]),
                Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));
            roversDictionary.Add(name, battleRover);
        }

        public void MoveRover(string name, string moveInstructions)
        {
            validator.ValidateMoveInstructions(moveInstructions);

            var activeRover = roversDictionary[name];
            var positionBeforeMove = new Position(activeRover.CurrentPosition.XPosition, activeRover.CurrentPosition.YPosition,
                activeRover.CurrentPosition.Direction);

            char[] instructions = moveInstructions.ToCharArray();
            foreach (char move in instructions)
            {
                if (move == 'L')
                {
                    activeRover.SpinLeft();
                }
                else if (move == 'R')
                {
                    activeRover.SpinRight();
                }
                else if (move == 'M')
                {
                    activeRover.Move();
                    try
                    {
                        validator.ValidateMovePositionForCollision(activeRover, roversDictionary);
                    }
                    catch (MoveException ex)
                    {
                        activeRover.CurrentPosition = positionBeforeMove;
                        throw ex;
                    }
                }
            }

            try
            {
                validator.ValidateMovePosition(activeRover, plateau);
            }
            catch (MoveException ex)
            {
                activeRover.CurrentPosition = positionBeforeMove;
                throw ex;
            }
        }

        public new Dictionary<string, BattleRover> GetRovers()
        {
            return roversDictionary;
        }
    }
}

