using Curiosity.Core.Contracts.Movement.MovementOptions;

namespace Curiosity.Core.Contracts.Movement;

public interface IMovement
{
    IMovementResult Move(IMovementOptions options);
}