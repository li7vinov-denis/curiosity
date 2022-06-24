using Curiosity.Core.Model.Directions;

namespace Curiosity.Core.Contracts.Movement;

public interface IRotationMovement : IMovement
{
    DirectionRotationType? RotationType { get; }
}