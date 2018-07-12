using System.Collections.Generic;
using Entitas;

[Game]
public sealed class LogDebugMessageSystem : ReactiveSystem<GameEntity>
{
  private readonly ILogService _logService;
  readonly GameContext _context;

  public LogDebugMessageSystem(Contexts contexts, ILogService logService): base(contexts.game)
  {
    _logService = logService;
    _context = contexts.game;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.DebugLog);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasDebugLog;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities)
    {
      _logService.LogMessage(entity.debugLog.message);
    }
  }
}
