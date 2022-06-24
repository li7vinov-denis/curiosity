using System.Collections.Generic;
using Curiosity.Core.Model;
using Curiosity.Tests.Cases;
using NUnit.Framework;

namespace Curiosity.Tests;

public class InputParserTests
{
    [TestCaseSource(typeof(InputParserTestCases), nameof(InputParserTestCases.SampleInput))]
    public void Parse(IReadOnlyCollection<string> input)
    {
        var parser = new InputParser();
        
        parser.ParseInput(input);
        
        Assert.IsNotNull(parser.Model.Polygon);
        Assert.IsNotNull(parser.Model.Polygon);
        Assert.IsNotEmpty(parser.Model.Robots);
    }
}