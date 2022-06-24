using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Extensions.Movement;

internal static class MovementResultExtensions
{
    internal static void Deconstruct(this IMovementResult result, out DirectionType direction, out IPosition position)
    {
        direction = result.DirectionType;
        position = result.Position;
    }
}