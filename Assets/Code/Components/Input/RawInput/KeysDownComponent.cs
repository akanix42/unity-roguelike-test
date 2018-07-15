using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
public class KeysDownComponent : IComponent
{
  public IEnumerable<KeyCode> keys;
}
