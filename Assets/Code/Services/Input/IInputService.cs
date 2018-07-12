using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
  Vector3 mousePosition { get; }
  bool isMouse1Down { get; }
  bool isMouse2Down { get; }
  bool isMouse1Held { get; }
  bool isMouse2Held { get; }
  bool areAnyKeysDown { get; }
  bool areAnyKeysHeld { get; }
  IEnumerable<GameKey> keysHeld { get; }
  void SetAvailableKeys(IEnumerable<KeyCode> keyCodes);
}