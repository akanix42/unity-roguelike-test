
using Entitas;

[Game]
public sealed class MoveCommand : IComponent
{
  public IntVector2 direction;
  public GameBoardElementPosition targetPosition;
}
