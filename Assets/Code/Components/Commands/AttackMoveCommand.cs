using Entitas;

[Game]
public sealed class AttackMoveCommand : IComponent
{
  public GameDirection direction;
}

public enum GameDirection
{
  Down,
  DownLeft,
  DownRight,
  Left,
  Right,
  Up,
  UpLeft,
  UpRight,
}
