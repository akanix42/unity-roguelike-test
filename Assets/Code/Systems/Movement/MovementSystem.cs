using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

[Game]
public sealed class MovementSystem : ReactiveSystem<GameEntity>, ICleanupSystem
{
  private readonly IGroup<GameEntity> _entitiesWithMoveCommands;

  public MovementSystem(Contexts contexts) : base(contexts.game)
  {
    _entitiesWithMoveCommands = contexts.game.GetGroup(GameMatcher.AttackMoveCommand);
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.AttackMoveCommand));
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasPosition && entity.hasAttackMoveCommand;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities)
    {
      var direction = entity.attackMoveCommand.direction;
      var position = entity.position;
      entity.ReplacePosition(position.levelId, position.x + direction.x, position.y + direction.y);
    }
  }

  public void Cleanup()
  {
    foreach (var entityWithMoveCommand in _entitiesWithMoveCommands.GetEntities())
    {
      entityWithMoveCommand.RemoveAttackMoveCommand();
    }
  }
}