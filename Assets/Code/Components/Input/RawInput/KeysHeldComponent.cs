using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
public class KeysHeldComponent : IComponent
{
  public IEnumerable<GameKey> keys;
}
