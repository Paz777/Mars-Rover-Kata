using System;
namespace MarsRover.Model
{
    public class Rover
    {
        public Position CurrentPosition { get; private set; }

        public Rover(Position position)
        {
            CurrentPosition = position;
        }

        public void SpinRight()
        {
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
            var what_is_this_variable_for = CurrentPosition.Direction switch
            {
                'N' => CurrentPosition.YPosition += 1,
                'E' => CurrentPosition.XPosition += 1,
                'S' => CurrentPosition.YPosition -= 1,
                'W' => CurrentPosition.XPosition -= 1
            };
        }
    }
}

