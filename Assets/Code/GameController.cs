using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
  private Systems _systems;

  private Contexts _contexts;

  private Services _services;

  void Awake()
  {
    _contexts = Contexts.sharedInstance;
    _services = CreateServices(_contexts, this);
  }

  void Start()
  {
    _systems = CreateSystems(_contexts, _services);
    _systems.Initialize();

    _contexts.game.isMainGameScreen = true;

    _contexts.level.ReplaceLevelId(0);

    var level = _services.level.CreateLevel();
    
//    for (var x = 0; x < level.level.columns; x++)
//    {
//      for (var y = 0; y < level.level.columns; y++)
//      {
//        var entity = _contexts.game.CreateEntity();
//        entity.isTargetedByUi = true;
//        entity.AddAsset("Tile");
////    entity.AddAsciiSprite("DejaVuSansMono_2");
//        entity.AddAsciiSprite("hashtag");
//        entity.AddPosition(level.level.id, x, y);
//        entity.isTile = true;
//        entity.isVisible = true;
////    entity.AddVisible(1);
////    entity.isVisible = false;
//      }
//      
//    }
    
  }

  void Update()
  {
    _systems.Execute();
    _systems.Cleanup();
  }

  private static Services CreateServices(Contexts contexts, GameController gameController)
  {
    return new Services(
      new UnityDebugLogService(),
      new UnityInputService(),
      new SpritesService(),
      new LevelService(contexts),
      new ViewService(contexts, gameController.transform)
    );
  }

  private static Systems CreateSystems(Contexts contexts, Services services)
  {
    return new Feature("Systems")
        .Add(new ServiceRegistrationSystem(contexts, services))
        .Add(new LogDebugMessageSystem(contexts, services.log))
        // Input
        .Add(new InputFeature(contexts, services.input))
        
        // Update
        .Add(new GenerateLevelSystem(contexts))
        
        // Events
        .Add(new GameEventSystems(contexts))
      ;
  }
}