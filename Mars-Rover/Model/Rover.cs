using System;
namespace MarsRover.Model
{
    public class Rover
    {
        private Plateau plateau;
        public Position CurrentPosition { get; private set; }

        public Rover(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public void PlaceRoverOnPlateau(Position position)
        {
            if ((position.XPosition > plateau.Width) || (position.YPosition > plateau.Height))
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
            else
            {
                CurrentPosition = position;
            }
        }

        public void SpinRight()
        {
            CheckPositionIsNull();
            CurrentPosition.Direction = CurrentPosition.Direction switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N'
            };
        }

        public void SpinLeft()
        {
            CheckPositionIsNull();
            CurrentPosition.Direction = CurrentPosition.Direction switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N'
            };
        }

        public void Move()
        {
            CheckPositionIsNull();
            var what_is_this_variable_for = CurrentPosition.Direction switch
            {
                'N' => CurrentPosition.YPosition += 1,
                'E' => CurrentPosition.XPosition += 1,
                'S' => CurrentPosition.YPosition -= 1,
                'W' => CurrentPosition.XPosition -= 1
            };
        }

        private void CheckPositionIsNull()
        {
            if (CurrentPosition is null)
            {
                throw new NullReferenceException("Rover has not been placed on the Plateau.");
            }
        }
    }
}

