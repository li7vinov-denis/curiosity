using System.Collections.Generic;

namespace Curiosity.Tests.Cases;

internal class InputParserTestCases
{
    internal static IReadOnlyCollection<IReadOnlyCollection<string>> SampleInput() => new[]
    {
        new[]
        {
            "5 3",
            
            "1 1 E",
            "RFRFRFRF",
            
            "3 2 N",
            "FRRFLLFFRRFLL",
            
            "0 3 W",
            "LLFFFLFLFL"
        }
    };
}