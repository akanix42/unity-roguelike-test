using Entitas;
using UnityEngine;

public sealed class AIMindlessWanderSystem : IExecuteSystem, ICleanupSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public AIMindlessWanderSystem(Contexts contexts)
  {
    _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.AI, GameMatcher.Acting));
  }

  public void Execute()
  {
    foreach (var entity in _entities)
    {
      var x = Random.Range(-1, 1);
      var y = Random.Range(-1, 1);
      
      entity.ReplaceAttackMoveCommand(new IntVector2(x, y));
    }
  }

  public void Cleanup()
  {
    foreach (var entity in _entities.GetEntities())
    {
      entity.isActing = false;
    }
  }
}