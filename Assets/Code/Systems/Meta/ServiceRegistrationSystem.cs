using Entitas;

public sealed class ServiceRegistrationSystem : IInitializeSystem
{
  private readonly Services _services;
  private readonly MetaContext _metaContext;

  public ServiceRegistrationSystem(Contexts contexts, Services services)
  {
    _metaContext = contexts.meta;
    _services = services;
  }

  public void Initialize()
  {
    _metaContext.ReplaceSpriteService(_services.sprites);
  }
}