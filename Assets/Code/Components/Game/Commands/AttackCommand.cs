
using Entitas;

[Game]
public sealed class AttackCommand : IComponent
{
  public GameBoardElementPosition targetPosition;
}
