using Curiosity.Core.Contracts.Movement;

namespace Curiosity.Core.Model.Directions;

internal static class DirectionChanger
{
    internal static DirectionType ChangeDirection(DirectionType direction, IMovement movement)
    {
        if (movement is not IRotationMovement rotationMovement)
            return direction;
        
        return rotationMovement.RotationType switch
        {
            DirectionRotationType.Right => RotateRight(direction),
            DirectionRotationType.Left => RotateLeft(direction),
            _ => throw new ArgumentOutOfRangeException($"Unknown {nameof(DirectionRotationType)} has been presented for change direction")
        };   
    }

    private static DirectionType RotateRight(DirectionType direction)
    {
        if (direction == DirectionType.West)
            return DirectionType.North;

        return direction + 1;
    }

    private static DirectionType RotateLeft(DirectionType direction)
    {
        if (direction == DirectionType.North)
            return DirectionType.West;

        return direction - 1;
    }
}