using MarsRover.Core.Constants;

namespace MarsRover.Core.Models
{
    public class RoadMap
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public string Command { get; set; }
    }
}