using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Robot;

namespace Curiosity.Core.Contracts.Coordinates;

public interface IPolygon
{
    IRobotInfoAdapter RobotInfoAdapter { get; }
    
    void MoveInside(IRobot robot, IReadOnlyCollection<IMovement> movements);
    bool IsPositionInside(IPosition position);
}