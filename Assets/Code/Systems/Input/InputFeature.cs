public sealed class InputFeature : Feature
{
  public InputFeature(Contexts contexts, IInputService inputService) : base("Input Systems")
  {
    Add(new EmitInputSystem(contexts, inputService));
    Add(new LevelScreenInputSystem(contexts, inputService));
    Add(new ViewInventoryScreenSystem(contexts));
  }
}