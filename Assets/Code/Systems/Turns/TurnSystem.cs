using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

[Game]
public sealed class TurnSystem : ReactiveSystem<GameEntity>
{
  readonly GameContext _context;

  public TurnSystem(Contexts contexts): base(contexts.game)
  {
    _context = contexts.game;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Actor);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.isActor;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    
  }

}


//using Entitas;
//
//public sealed class TurnSystem : IExecuteSystem
//{
//  private readonly IGroup<GameEntity> entities;
//  
//  public TurnSystem(Contexts contexts)
//  {
//    entities = contexts.game.GetGroup(GameMatcher.Actor);
//  }
//
//  public void Execute()
//  {
//    foreach (var entity in entities.GetEntities())
//    {
//      
//    }
//  }
//}