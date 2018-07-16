using System;
using Entitas;
using Random = UnityEngine.Random;

public sealed class AIMindlessWanderSystem : IExecuteSystem, ICleanupSystem
{
  private readonly IGroup<GameEntity> _entities;
  private readonly LevelContext _levelContext;

  public AIMindlessWanderSystem(Contexts contexts)
  {
    _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.AI, GameMatcher.Acting));

    _levelContext = contexts.level;
  }

  public void Execute()
  {
    foreach (var entity in _entities)
    {
      var position = entity.position.value;
      var level = _levelContext.GetEntityWithLevel(position.levelId).level;
      var x = GetRandomPosition(position.x, level.columns);
      var y = GetRandomPosition(position.x, level.rows);

      entity.ReplaceMoveCommand(new IntVector2(x - position.x, y - position.y), GameBoardElementPosition.Create(position.levelId, x, y));
    }
  }

  private static int GetRandomPosition(int currentValue, int maxExclusive)
  {
    return Random.Range(Math.Max(currentValue - 1, 0), Math.Min(currentValue + 2, maxExclusive));
  } 
  
  public void Cleanup()
  {
    foreach (var entity in _entities.GetEntities())
    {
//      entity.isActing = false;
      entity.ReplaceTurnCount(entity.hasTurnCount ? entity.turnCount.value + 1 : 1);
    }
  }
}