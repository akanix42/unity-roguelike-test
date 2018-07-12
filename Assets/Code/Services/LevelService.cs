public class LevelService
{
  private readonly Contexts _contexts;

  public LevelService(Contexts contexts)
  {
    _contexts = contexts;
  }

  public GameEntity CreateLevel()
  {
    var game = _contexts.game;
    var entity = game.CreateEntity();
    entity.AddLevel(game.levelId.nextId, 5, 5);
    entity.isUngeneratedLevel = true;
    game.ReplaceLevelId(game.levelId.nextId + 1);
    return entity;
  }
}