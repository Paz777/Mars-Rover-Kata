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
            if ((position.X > plateau.X) || (position.Y > plateau.Y)) 
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
            else
            {
                CurrentPosition = position;
            }
        }
    }
}

