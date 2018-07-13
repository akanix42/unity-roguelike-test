using Entitas;

public sealed class RenderTilesSystem : IExecuteSystem
{
  private readonly ISpritesService _spritesService;
  private readonly IGroup<GameEntity> _tiles;
  
  public RenderTilesSystem(Contexts contexts, ISpritesService spritesService)
  {
    _spritesService = spritesService;
    _tiles = contexts.game.GetGroup(GameMatcher.Tile);
  }

  public void Execute()
  {
    foreach (var entity in _tiles.GetEntities())
    {
    }
  }
}