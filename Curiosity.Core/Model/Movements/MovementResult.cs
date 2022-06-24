using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Model.Movements;

public class MovementResult : IMovementResult
{
    public DirectionType DirectionType { get; }
    public IPosition Position { get; }

    public MovementResult(DirectionType directionType, IPosition position)
    {
        DirectionType = directionType;
        Position = position;
    }
}