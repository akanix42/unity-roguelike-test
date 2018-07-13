using Entitas;
using Entitas.CodeGeneration.Attributes;

[Level]
[Unique]
public sealed class LevelIdComponent : IComponent
{
  public int nextId;
}
