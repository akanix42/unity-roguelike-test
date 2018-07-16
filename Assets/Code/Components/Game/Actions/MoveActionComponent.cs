using Entitas;

[Game]
public sealed class MoveActionComponent : IComponent
{
  public GameBoardElementPosition targetPosition;
}