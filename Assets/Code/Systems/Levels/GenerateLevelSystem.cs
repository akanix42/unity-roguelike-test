using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

[Game]
public sealed class GenerateLevelSystem : ReactiveSystem<GameEntity>
{
  readonly GameContext _game;

  public GenerateLevelSystem(Contexts contexts): base(contexts.game)
  {
    _game = contexts.game;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.UngeneratedLevel);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.isUngeneratedLevel;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities)
    {
      GenerateLevel(entity);
      
    }
  }

  private void GenerateLevel(GameEntity levelEntity)
  {
    var level = levelEntity.level;
    for (var x = 0; x < level.columns; x++)
    {
      for (var y = 0; y < level.rows; y++)
      {
        var tile = _game.CreateEntity();
        tile.isTile = true;
        tile.AddPosition(level.id, x, y);
        tile.AddFloor("dirt");
      }
    }
  }
}
