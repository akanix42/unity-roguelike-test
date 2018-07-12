using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class LevelComponent : IComponent
{
  [PrimaryEntityIndex]
  public int id;
  
  public int columns;
  public int rows;
}
