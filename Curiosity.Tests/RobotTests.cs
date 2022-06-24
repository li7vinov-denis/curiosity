using System.Collections.Generic;
using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Robot;
using Curiosity.Core.Model;
using Curiosity.Core.Model.Coordinates;
using Curiosity.Core.Model.Directions;
using Curiosity.Core.Model.Movements;
using Curiosity.Tests.Cases;
using NUnit.Framework;

namespace Curiosity.Tests;

public class RobotTests
{
    private IPolygon _polygon;

    public RobotTests()
    {
        _polygon = new Polygon(new Position(5, 3));
    }
    
    [TestCaseSource(typeof(RobotTestCases), nameof(RobotTestCases.InitialRobot))]
    public void CanRotate(Robot robot)
    {
        var robotDirection = robot.CurrentDirection;

        robot.Move(new Left());
        
        Assert.AreNotEqual(robotDirection, robot.CurrentDirection);
    }

    [TestCaseSource(typeof(RobotTestCases), nameof(RobotTestCases.InitialRobot))]
    public void CanMove(Robot robot)
    {
        var positionX = robot.CurrentPosition.X;
        
        robot.Move(new Forward());
        
        Assert.AreNotEqual(positionX, robot.CurrentPosition.X);
    }

    [TestCaseSource(typeof(RobotMovements), nameof(RobotMovements.Cases))]
    public void MoveInside((IRobot robot, IReadOnlyCollection<IMovement> movements, IPosition expectedPosition, DirectionType expectedDirection, StateType expectedState) testCase)
    {
        var (robot, movements, expectedPosition, expectedDirection, expectedState) = testCase;
        
        _polygon.MoveInside(robot, movements);
        
        Assert.AreEqual(expectedPosition.X, robot.CurrentPosition.X);
        Assert.AreEqual(expectedPosition.Y, robot.CurrentPosition.Y);
        Assert.AreEqual(expectedDirection, robot.CurrentDirection);
        Assert.AreEqual(expectedState, robot.State);
    }
}