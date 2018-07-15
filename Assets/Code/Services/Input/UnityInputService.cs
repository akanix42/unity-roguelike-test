using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class UnityInputService : IInputService
{
  public float keyDelay = 0.2f;
  private float timeSinceLastKeypress = 0f;

  private readonly KeyCode[] _emptyKeyCodes = new KeyCode[0];
  private IEnumerable<KeyCode> _keyCodes;

  private List<KeyCode> _modifierKeys = new List<KeyCode>
  {
    KeyCode.LeftShift,
    KeyCode.RightShift,
    KeyCode.LeftAlt,
    KeyCode.RightAlt,
    KeyCode.LeftControl,
    KeyCode.RightControl,
  };

  public UnityInputService()
  {
    _keyCodes = _emptyKeyCodes;
  }

  public Vector3 mousePosition
  {
    get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); }
  }

  public bool isMouse1Down
  {
    get { return Input.GetMouseButtonDown(0); }
  }

  public bool isMouse2Down
  {
    get { return Input.GetMouseButtonDown(1); }
  }

  public bool isMouse1Held
  {
    get { return Input.GetMouseButton(0); }
  }

  public bool isMouse2Held
  {
    get { return Input.GetMouseButton(1); }
  }

  public bool areAnyKeysDown
  {
    get { return Input.anyKeyDown; }
  }

  public bool areAnyKeysHeld
  {
    get { return Input.anyKey; }
  }

  public IEnumerable<GameKey> keysHeld
  {
    get
    {
      timeSinceLastKeypress += Time.deltaTime;
      if (timeSinceLastKeypress < keyDelay)
        return new GameKey[0];

      var isShiftDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
      var isAltDown = Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt);
      var isControlDown = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);

      var modifiers = GameKeyModifiers.None;
      if (isAltDown)
      {
        modifiers = modifiers | GameKeyModifiers.AltPressed;
      }

      if (isShiftDown)
      {
        modifiers = modifiers | GameKeyModifiers.ShiftPressed;
      }

      if (isControlDown)
      {
        modifiers = modifiers | GameKeyModifiers.CtrlPressed;
      }

      var keysHeld = _keyCodes.Where(Input.GetKey).Except(_modifierKeys).Select(keycode => new GameKey(keycode, modifiers)).ToList();
      if (keysHeld.Any())
      {
        timeSinceLastKeypress = 0;
      }
      return keysHeld;
    }
  }

  public void SetAvailableKeys(IEnumerable<KeyCode> keyCodes)
  {
    _keyCodes = keyCodes ?? _emptyKeyCodes;
  }
}