public class GameEntityService
{
  private readonly Contexts _contexts;

  public GameEntityService(Contexts contexts)
  {
    _contexts = contexts;
  }

  public GameEntity CreatePlayer()
  {
    var entity = _contexts.game.CreateEntity();
    entity.isTargetedByUi = true;
    entity.AddAsset("GameBoardElement");
    entity.AddAsciiSprite("at-sign");
    entity.isVisible = true;
    entity.isInteractive = true;
    return entity;
  }
}