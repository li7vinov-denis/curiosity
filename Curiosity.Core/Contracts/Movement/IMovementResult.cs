using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Contracts.Movement;

public interface IMovementResult
{
    DirectionType DirectionType { get; }
    IPosition Position { get; }
}