public class Services
{
  public ILogService log;
  public IInputService input;
  public ISpritesService sprites;
  public LevelService level;
  public ViewService view;
  
  public Services(
    ILogService log,
    IInputService input,
    ISpritesService sprites,
    LevelService level,
    ViewService view
    )
  {
    this.log = log;
    this.input = input;
    this.sprites = sprites;
    this.level = level;
    this.view = view;
  }
}