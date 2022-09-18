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
            if (CurrentPosition is null)
            {
                throw new NullReferenceException("Rover has not been placed on the Plateau.");
            }
            CurrentPosition.Direction = CurrentPosition.Direction switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N'
            };
        }
    }
}

