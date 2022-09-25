using MarsRover.Model;

namespace MarsRover.Model
{
    public class BattleRover :  Rover
    {
        public string Name { get; private set; }

        public BattleRover(string name, Position position) : base(position)
        {
            Name = name;
        }
    }
}

