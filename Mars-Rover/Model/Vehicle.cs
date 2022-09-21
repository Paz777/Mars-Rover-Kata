using MarsRover.Interface;

namespace MarsRover.Model
{
    public abstract class Vehicle : IVehicle
    {
        public Position CurrentPosition { get; set; }

        public Vehicle()
        {
        }

        public abstract void Move();
        public abstract void SpinLeft();
        public abstract void SpinRight();
    }
}

