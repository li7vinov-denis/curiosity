using System.Collections.Generic;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Model.Movements;

namespace Curiosity.Tests.Cases;

internal class MovementsTestCases
{
    internal static IReadOnlyCollection<IReadOnlyCollection<IMovement>> Movements() => new List<List<IMovement>>
    {
        new()
        {
            new Right(),
            new Forward(),
            new Right(),
            new Forward(),
            new Right(),
            new Forward(),
            new Right(),
            new Forward()
        },
        new()
        {
            new Forward(),
            new Right(),
            new Right(),
            new Forward(),
            new Left(),
            new Left(),
            new Forward(),
            new Forward(),
            new Right(),
            new Right(),
            new Forward(),
            new Left(),
            new Left()
        },
        new()
        {
            new Left(),
            new Left(),
            new Forward(),
            new Forward(),
            new Forward(),
            new Left(),
            new Forward(),
            new Left(),
            new Forward(),
            new Left(),
        }
    }.AsReadOnly();
}