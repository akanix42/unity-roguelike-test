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

  public GameEntity CreateNpc()
  {
    var entity = _contexts.game.CreateEntity();
    entity.AddAsset("GameBoardElement");
    entity.AddAsciiSprite("z");
    entity.isVisible = true;
    entity.AddAI("MindlessWander");
    return entity;
  }

  public GameEntity CreateInvisibleNpc()
  {
    var entity = _contexts.game.CreateEntity();
    entity.AddAsciiSprite("z");
    entity.isVisible = true;
    entity.isPhysicalBarrier = true;
    entity.AddAI("MindlessWander");
    return entity;
  }
}