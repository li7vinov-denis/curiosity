using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Robot;
using Curiosity.Core.Extensions.Movement;
using Curiosity.Core.Model.Directions;
using Curiosity.Core.Model.Movements.Options;

namespace Curiosity.Core.Model;

public class Robot : IRobot
{
    public Guid Id { get; }
    public StateType State { get; private set; }
    public DirectionType CurrentDirection { get; private set; }
    public IPosition CurrentPosition { get; private set; }

    public Robot(Guid id, IPosition currentPosition, DirectionType currentDirection)
    {
        Id = id;
        CurrentPosition = currentPosition;
        CurrentDirection = currentDirection;
        State = StateType.Normal;
    }

    public IPosition Move(IMovement movement)
    {
        (CurrentDirection, var currentPosition) = movement.Move(new MovementOption(CurrentDirection, CurrentPosition));

        CurrentPosition = currentPosition ?? CurrentPosition;
        
        return CurrentPosition;
    }

    public IPosition CalculatePosition(IMovement movement)
    {
        var (_, position) = movement.Move(new MovementOption(CurrentDirection, CurrentPosition));

        return position ?? CurrentPosition;
    }

    public void SetState(StateType state)
    {
        State = state;
    }
}