using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta, Unique]
public sealed class SpriteServiceComponent : IComponent
{
  public ISpritesService instance;
}
