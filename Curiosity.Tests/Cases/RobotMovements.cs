using System.Collections.Generic;
using System.Linq;
using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Robot;
using Curiosity.Core.Model.Coordinates;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Tests.Cases;

public static class RobotMovements
{
    internal static List<(IRobot robot, IReadOnlyCollection<IMovement> movements, IPosition expectedPosition, DirectionType expectedDirection, StateType state)> Cases() => new ()
    {
        (RobotTestCases.Robots().FirstOrDefault(), MovementsTestCases.Movements().FirstOrDefault(), new Position(1,1), DirectionType.East, StateType.Normal),
        (RobotTestCases.Robots().Skip(1).FirstOrDefault(), MovementsTestCases.Movements().Skip(1).FirstOrDefault(), new Position(3,3), DirectionType.North, StateType.Lost),
        (RobotTestCases.Robots().Skip(2).FirstOrDefault(), MovementsTestCases.Movements().Skip(2).FirstOrDefault(), new Position(2,3), DirectionType.South, StateType.Normal)
    };
}