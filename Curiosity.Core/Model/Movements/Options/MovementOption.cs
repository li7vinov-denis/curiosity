using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement.MovementOptions;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Model.Movements.Options;

internal class MovementOption : IDistanceMovementOptions, IRotationMovementOptions
{
    public DirectionType Direction { get; }
    public IPosition Position { get; }

    public MovementOption(DirectionType direction, IPosition position)
    {
        Direction = direction;
        Position = position;
    }
}