using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Event(EventTarget.Self)]
public sealed class AsciiSpriteComponent : IComponent
{
  public string value;
}
