namespace MarsRover.Model
{
    public class Rover : Vehicle
    {
        public Rover(Position position)
        {
            CurrentPosition = position;
        }

        public override void SpinRight()
        {
            CurrentPosition.Direction = CurrentPosition.Direction switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N'
            };
        }

        public override void SpinLeft()
        {
            CurrentPosition.Direction = CurrentPosition.Direction switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N'
            };
        }

        public override void Move()
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

