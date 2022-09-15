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
            CurrentPosition = position;
        }
    }
}

