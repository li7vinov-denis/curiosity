using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Extensions.Direction;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Model.Coordinates;

public class Position : IPosition
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position(IPosition oldPosition, DirectionType direction, int newValue)
    {
        if (direction.IsVertical())
        {
            Y = newValue;
            X = oldPosition.X;
        }
        else
        {
            Y = oldPosition.Y;
            X = newValue;
        }
    }

    public int GetTargetAxis(DirectionType direction) => direction.IsVertical() ? Y : X;
}