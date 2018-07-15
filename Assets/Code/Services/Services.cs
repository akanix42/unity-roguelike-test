public class Services
{
  public ILogService log;
  public IInputService input;
  public ISpritesService sprites;
  public LevelService level;
  public ViewService view;
  public GameEntityService gameEntity;
  
  public Services(
    ILogService log,
    IInputService input,
    ISpritesService sprites,
    LevelService level,
    ViewService view,
    GameEntityService gameEntity
    )
  {
    this.log = log;
    this.input = input;
    this.sprites = sprites;
    this.level = level;
    this.view = view;
    this.gameEntity = gameEntity;
  }
}