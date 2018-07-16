using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

[Level]
public sealed class GenerateLevelSystem : ReactiveSystem<LevelEntity>
{
  readonly GameContext _game;

  public GenerateLevelSystem(Contexts contexts) : base(contexts.level)
  {
    _game = contexts.game;
  }

  protected override ICollector<LevelEntity> GetTrigger(IContext<LevelEntity> context)
  {
    return context.CreateCollector(LevelMatcher.UngeneratedLevel);
  }

  protected override bool Filter(LevelEntity entity)
  {
    return entity.isUngeneratedLevel;
  }

  protected override void Execute(List<LevelEntity> entities)
  {
    foreach (var entity in entities)
    {
      GenerateLevel(entity);
    }
  }

  private void GenerateLevel(LevelEntity levelEntity)
  {
    var level = levelEntity.level;
    for (var x = 0; x < level.columns; x++)
    {
      for (var y = 0; y < level.rows; y++)
      {
        var tile = _game.CreateEntity();
        tile.isTile = true;
        tile.AddPosition(GameBoardElementPosition.Create(level.id, x, y));
        tile.AddFloor("dirt");
        tile.AddAsset("GameBoardElement");
//    entity.AddAsciiSprite("DejaVuSansMono_2");
        tile.AddAsciiSprite("dot");
        tile.isVisible = true;
      }
    }

    levelEntity.isUngeneratedLevel = false;
  }
}