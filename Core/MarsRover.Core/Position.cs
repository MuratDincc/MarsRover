using MarsRover.Core.Interfaces;

namespace MarsRover.Core
{
    public class Position : IPosition
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Position(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
    }
}