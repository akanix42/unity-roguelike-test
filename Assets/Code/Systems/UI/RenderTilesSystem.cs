using Entitas;

public sealed class RenderTilesSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _tiles;
  
  public RenderTilesSystem(Contexts contexts)
  {
    _tiles = contexts.game.GetGroup(GameMatcher.Tile);
  }

  public void Execute()
  {
    foreach (var entity in _tiles.GetEntities())
    {
      
    }
  }
}