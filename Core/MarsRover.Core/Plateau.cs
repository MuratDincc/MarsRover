using MarsRover.Core.Interfaces;

namespace MarsRover.Core
{
    public class Plateau : IPlateau
    {
        public Position Position { get; private set; }

        public Plateau(Position position)
        {
            Position = position;
        }
    }
}