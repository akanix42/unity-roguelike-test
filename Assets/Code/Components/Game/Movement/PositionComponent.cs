using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self)]
public sealed class PositionComponent : IComponent
{
  public int levelId;
  public int x;
  public int y;
}
