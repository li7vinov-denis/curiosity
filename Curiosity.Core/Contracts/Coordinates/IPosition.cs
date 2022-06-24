using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Contracts.Coordinates;

public interface IPosition
{
    int X { get; }
    int Y { get; }
    int GetTargetAxis(DirectionType direction);
}