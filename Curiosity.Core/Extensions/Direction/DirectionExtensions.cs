using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Extensions.Direction;

internal static class DirectionExtensions
{
    private static readonly IReadOnlyCollection<DirectionType> NegativeDirectionTypes = new[] {DirectionType.South, DirectionType.West};
    private static readonly IReadOnlyCollection<DirectionType> VerticalDirectionTypes = new[] {DirectionType.North, DirectionType.South};
    private const int NegativeMultiplier = -1;
    private const int PositiveMultiplier = 1;

    internal static int GetStepMultiplier(this DirectionType direction)
    {
        if (NegativeDirectionTypes.Contains(direction))
        {
            return NegativeMultiplier;
        }

        return PositiveMultiplier;
    }

    internal static bool IsVertical(this DirectionType direction)
    {
        return VerticalDirectionTypes.Contains(direction);
    }
}