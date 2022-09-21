using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface IVehicle
    {
        public Position CurrentPosition { get; set; }

        public void SpinRight();
        public void SpinLeft();
        public void Move();
    }
}

