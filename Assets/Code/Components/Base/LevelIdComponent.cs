using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
public sealed class LevelIdComponent : IComponent
{
  public int nextId;
}
