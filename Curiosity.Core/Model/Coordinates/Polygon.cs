using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Robot;
using Curiosity.Core.Model.Exceptions;

namespace Curiosity.Core.Model.Coordinates;

public class Polygon : IPolygon
{
    private readonly Scents _scents;
    private IPosition TopRight { get; }
    private IPosition BottomLeft { get; }

    public IRobotInfoAdapter RobotInfoAdapter { get; }

    private Polygon(IPosition bottomLeft, IPosition topRight, IRobotInfoAdapter adapter = null)
    {
        BottomLeft = bottomLeft;
        TopRight = topRight;
        RobotInfoAdapter = adapter;

        _scents = new Scents();
    }

    public Polygon(IPosition topRight, IRobotInfoAdapter adapter = null) : this(new Position(0, 0), topRight, adapter)
    {
        TopRight = topRight;
    }

    public void MoveInside(IRobot robot, IReadOnlyCollection<IMovement> movements)
    {
        foreach (var movement in movements)
        {
            try
            {
                if (_scents.IsThatPositionScent(robot.CalculatePosition(movement), robot))
                    continue;
                
                var position = robot.Move(movement);

                if (IsPositionInside(position))
                    continue;

                _scents.Add(position, robot);

                robot.SetState(StateType.Lost);
            }
            catch (MovementException e)
            {
                RobotInfoAdapter?.MovementInfo(e.Message);
            }
        }

        RobotInfoAdapter?.EndMovementInfo(robot);
    }

    public bool IsPositionInside(IPosition position)
    {
        var verticalInside = TopRight.Y >= position.Y && position.Y >= BottomLeft.Y;
        var horizontalInside = TopRight.X >= position.X && position.X >= BottomLeft.X;

        return verticalInside && horizontalInside;
    }
}