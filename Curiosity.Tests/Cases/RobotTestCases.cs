using System;
using System.Collections.Generic;
using Curiosity.Core.Contracts.Robot;
using Curiosity.Core.Model;
using Curiosity.Core.Model.Coordinates;
using Curiosity.Core.Model.Directions;

namespace Curiosity.Tests.Cases;

internal class RobotTestCases
{
    internal static IReadOnlyCollection<IRobot> Robots() => new[]
    {
        _initialRobot(),
        new Robot(new Guid("FD72DC27-60A3-4949-9AF6-85EBDD2B8716"), new Position(3, 2), DirectionType.North),
        new Robot(new Guid("7A0E44B2-CD1B-4934-B955-359F60940D64"), new Position(0, 3), DirectionType.West)
    };

    internal static IReadOnlyCollection<IRobot> InitialRobot() => new[]
    {
        _initialRobot()
    };

    private static Robot _initialRobot() => new(new Guid("D5B5AE5B-80D4-4A26-9087-C131F4481F2E"), new Position(1, 1),
        DirectionType.East);
}