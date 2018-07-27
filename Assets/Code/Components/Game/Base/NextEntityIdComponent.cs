using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
public sealed class NextEntityIdComponent : IComponent
{
  public string value;
}
