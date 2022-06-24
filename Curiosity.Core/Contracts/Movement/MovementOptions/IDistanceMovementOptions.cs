using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Contracts.Movement.MovementOptions;

public interface IDistanceMovementOptions : IMovementOptions
{
    public DirectionType Direction { get; }
    public IPosition Position { get; }
}