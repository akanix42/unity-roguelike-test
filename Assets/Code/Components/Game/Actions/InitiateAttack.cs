using Entitas;

[Game]
public sealed class InitiateAttack : IComponent
{
  public GameBoardElementPosition targetPosition;
}
