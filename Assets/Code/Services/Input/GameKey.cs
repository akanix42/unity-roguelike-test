using UnityEngine;

public struct GameKey
{
  public readonly KeyCode keyCode;
  public readonly GameKeyModifiers modifiers;

  public GameKey(KeyCode keyCode, GameKeyModifiers modifiers = GameKeyModifiers.None)
  {
    this.keyCode = keyCode;
    this.modifiers = modifiers;
  }
}