using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
  private Systems _systems;

  private Contexts _contexts;

  private Services _services;

  void Start()
  {
    _contexts = Contexts.sharedInstance;
    _services = CreateServices();
    _systems = CreateSystems(_contexts, _services);
    _systems.Initialize();

    _contexts.game.isMainGameScreen = true;
    var entity = _contexts.game.CreateEntity();
    entity.isTargetedByUi = true;
  }

  void Update()
  {
    _systems.Execute();
    _systems.Cleanup();
  }

  private static Services CreateServices()
  {
    return new Services()
    {
      log = new UnityDebugLogService(),
      input = new UnityInputService(),
    };
  }
  
  private static Systems CreateSystems(Contexts contexts, Services services)
  {
    return new Feature("Systems")
        .Add(new LogDebugMessageSystem(contexts, services.log))
        .Add(new InputFeature(contexts, services.input))
      ;
  }
}