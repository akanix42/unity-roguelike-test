
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
    var player = _services.gameEntity.CreatePlayer();
    player.ReplacePosition(GameBoardElementPosition.Create(level.level.id, 0, 0));

    for (var i = 0; i < 1; i++)
    {
      var npc = _services.gameEntity.CreateNpc();
      npc.ReplacePosition(GameBoardElementPosition.Create(level.level.id, 1, 1));
    }
    for (var i = 0; i < 10000; i++)
    {
      var npc = _services.gameEntity.CreateInvisibleNpc();
      npc.ReplacePosition(GameBoardElementPosition.Create(level.level.id, 1, 1));
    }
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
      new ViewService(contexts, gameController.transform),
      new GameEntityService(contexts)
    );
  }

  private static Systems CreateSystems(Contexts contexts, Services services)
  {
    return new Feature("Systems")
        .Add(new ServiceRegistrationSystem(contexts, services))
        .Add(new LogDebugMessageSystem(contexts, services.log))
        // User Input
        .Add(new InputFeature(contexts, services.input))

        // AI Input
        .Add(new AIMindlessWanderSystem(contexts))
        
        // Update
        .Add(new GenerateLevelSystem(contexts))
        .Add(new MovementCollisionSystem(contexts))
        .Add(new MovementSystem(contexts))
        .Add(new DebugStopActingSystem(contexts))
        .Add(new FocusCameraSystem(contexts))

        // Events
        .Add(new GameEventSystems(contexts))
      ;
  }
}