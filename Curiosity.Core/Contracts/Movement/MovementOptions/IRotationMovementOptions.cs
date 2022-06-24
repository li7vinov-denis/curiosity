using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Contracts.Movement.MovementOptions;

public interface IRotationMovementOptions : IMovementOptions
{
    public DirectionType Direction { get; }
}