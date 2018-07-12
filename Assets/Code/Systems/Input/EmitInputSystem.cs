using Entitas;

public sealed class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
  private readonly IInputService _inputService;
  private readonly InputContext _inputContext;
  private InputEntity _leftMouseEntity;
  private InputEntity _rightMouseEntity;
  private InputEntity _keysDownEntity;
  private InputEntity _inputEntity;

  public EmitInputSystem(Contexts contexts, IInputService inputService)
  {
    _inputService = inputService;
    _inputContext = contexts.input;
  }

  public void Initialize()
  {
    _inputContext.isInputManager = true;
    _inputEntity = _inputContext.inputManagerEntity;
  }

  public void Execute()
  {
    _inputEntity.ReplaceMousePosition(_inputService.mousePosition);
    _inputEntity.ReplaceKeysHeld(_inputService.keysHeld);
  }
}