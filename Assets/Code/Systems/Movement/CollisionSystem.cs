using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Entitas;
using Entitas.Unity;

[Game]
public sealed class MovementCollisionSystem : ReactiveSystem<GameEntity>
{
  readonly GameContext _gameContext;
  private LevelContext _levelContext;

  public MovementCollisionSystem(Contexts contexts) : base(contexts.game)
  {
    _gameContext = contexts.game;
    _levelContext = contexts.level;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.MoveCommand);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasMoveCommand;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    UnityEngine.Profiling.Profiler.BeginSample("Execute");
    foreach (var entity in entities)
    {
      HandleEntity(entity);
    }
    UnityEngine.Profiling.Profiler.EndSample();
  }

  private void HandleEntity(GameEntity entity)
  {
    var targetPosition = entity.moveCommand.targetPosition;
    entity.RemoveMoveCommand();

    var level = _levelContext.GetEntityWithLevel(targetPosition.levelId).level;
    
    if (targetPosition.x < 0 || targetPosition.x >= level.columns || targetPosition.y < 0 ||
        targetPosition.x >= level.rows)
    {
      entity.ReplaceMoveCanceled("out of bounds");
      return;
    }

//    UnityEngine.Profiling.Profiler.BeginSample("Retrieve Blockers 2");
//
//    var hasBlockers1 = CheckForBlockers2(targetPosition);
//    
////      .Any(targetEntity => targetEntity.isPhysicalBarrier);
//    UnityEngine.Profiling.Profiler.EndSample();

    UnityEngine.Profiling.Profiler.BeginSample("Retrieve Blockers");

    var hasBlockers = CheckForBlockers2(targetPosition);
    
//      .Any(targetEntity => targetEntity.isPhysicalBarrier);
    UnityEngine.Profiling.Profiler.EndSample();

    if (hasBlockers)
    {
      entity.ReplaceMoveCanceled("blocked");
//      entity.RemoveMoveCommand();
      return;
    }
    
    entity.AddMoveAction(targetPosition);
  }

  private bool CheckForBlockers2(GameBoardElementPosition position)
  {
//    return false;
    return _gameContext.GetPhysicalBarrierEntitiesWithPosition(position).Count > 0;
  }

  private bool CheckForBlockers(GameBoardElementPosition targetPosition)
  {
    UnityEngine.Profiling.Profiler.BeginSample("Get Position");

    var entities = _gameContext
      .GetEntitiesWithPosition(targetPosition);
    UnityEngine.Profiling.Profiler.EndSample();

//    int i = 0;
    UnityEngine.Profiling.Profiler.BeginSample("Iterate count");

    foreach (var entity in entities)
    {
      if (entity.isPhysicalBarrier)
      {
        return true;
      }
//      i++;
    }
    UnityEngine.Profiling.Profiler.EndSample();
    
//    UnityEngine.Profiling.Profiler.BeginSample("Iterate null check");
//
//    foreach (var entity in entities)
//    {
////      if (entity.isPhysicalBarrier)
////      {
////        return true;
////      }
//      if (entity == null)
//      {
//        return true;
//      }
//    }
//    UnityEngine.Profiling.Profiler.EndSample();

    return false;
  }
}