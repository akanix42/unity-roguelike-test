using System.Collections.Generic;

using Entitas;
using Entitas.Unity;

[Game]
public sealed class MovementSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
  private readonly IGroup<GameEntity> _entitiesWithMoveAction;

  public MovementSystem(Contexts contexts) : base(contexts.game)
  {
    _entitiesWithMoveAction = contexts.game.GetGroup(GameMatcher.MoveAction);
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.MoveAction));
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasPosition && entity.hasMoveAction;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities)
    {
      var position = entity.position.value;
      var targetPosition = entity.moveAction.targetPosition;
      
      entity.ReplacePosition(GameBoardElementPosition.Create(position.levelId, targetPosition.x, targetPosition.y));
    }
  }

  public void Cleanup()
  {
    foreach (var entity in _entitiesWithMoveAction.GetEntities())
    {
      entity.RemoveMoveAction();
    }
  }
}