using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Movement.MovementOptions;
using Curiosity.Core.Extensions.Direction;
using Curiosity.Core.Model.Coordinates;
using Curiosity.Core.Model.Exceptions;

namespace Curiosity.Core.Model.Movements;

public class Forward : IDistanceMovement
{
    private const int MovementStepSize = 1;
    public IMovementResult Move(IMovementOptions options)
    {
        if (options is not IDistanceMovementOptions distanceMovementOptions)
            throw new MovementException("Robot can't move forward, wrong parameters");

        var direction = distanceMovementOptions.Direction;
        var position = distanceMovementOptions.Position;
        
        var stepMultiplier = direction.GetStepMultiplier();
        var axis = position.GetTargetAxis(direction);

        var newValue = axis + MovementStepSize * stepMultiplier;

        return new MovementResult(direction, new Position(position, direction, newValue));
    }
}