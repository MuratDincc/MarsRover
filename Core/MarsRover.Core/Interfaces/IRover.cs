using MarsRover.Core.Constants;
using MarsRover.Core.Interfaces;

namespace MarsRover.Core
{
    public interface IRover
    {
        IPlateau Plateau { get; set; }
        IPosition Position { get; set; }
        Direction Direction { get; set; }

        string Current();
    }
}