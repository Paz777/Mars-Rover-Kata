using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface IMissionControl
    {
        public void AddPlateau(string input);
        public void AddRover(string input);
        public void MoveRover(string moveInstructions);
    }
}

