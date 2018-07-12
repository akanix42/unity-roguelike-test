using System.Collections.Generic;
using Entitas;

[Game]
public sealed class ViewInventoryScreenSystem : ReactiveSystem<GameEntity>
{
  readonly GameContext _context;

  public ViewInventoryScreenSystem(Contexts contexts): base(contexts.game)
  {
    _context = contexts.game;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.ViewInventoryCommand);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasViewInventoryCommand;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities)
    {
      entity.isDisplayingInventory = true;
      entity.hasViewInventoryCommand = false;
    }
  }

}
