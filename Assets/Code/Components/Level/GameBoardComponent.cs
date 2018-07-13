using Entitas;
using Entitas.CodeGeneration.Attributes;

[Level, Unique]
public sealed class GameBoardComponent : IComponent
{
  public int levelId;
  
  public int columns;
  public int rows;
}
