using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Movement.MovementOptions;
using Curiosity.Core.Model.Directions;
using Curiosity.Core.Model.Exceptions;

namespace Curiosity.Core.Model.Movements;

public class Left : IRotationMovement
{
    public DirectionRotationType? RotationType => DirectionRotationType.Left;

    public IMovementResult Move(IMovementOptions options)
    {
        if (options is not IRotationMovementOptions movementOptions)
            throw new MovementException("Robot can't turn left, wrong parameters");

        return new MovementResult(DirectionChanger.ChangeDirection(movementOptions.Direction, this), null);
    }
}