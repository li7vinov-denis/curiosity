using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Contracts.Robot;

public interface IRobot
{
    public Guid Id { get; }
    
    public StateType State { get; }
    
    DirectionType CurrentDirection { get;}
    IPosition CurrentPosition { get; }
    
    IPosition Move(IMovement movement);
    IPosition CalculatePosition(IMovement movement);

    void SetState(StateType state);
}