public class LevelService
{
  private readonly Contexts _contexts;

  public LevelService(Contexts contexts)
  {
    _contexts = contexts;
  }

  public LevelEntity CreateLevel()
  {
    var levelContext = _contexts.level;
    var entity = levelContext.CreateEntity();
    entity.AddLevel(levelContext.levelId.nextId, 10, 10);
    entity.isUngeneratedLevel = true;
    levelContext.ReplaceLevelId(levelContext.levelId.nextId + 1);
    return entity;
  }
}