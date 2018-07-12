using Entitas;
using UnityEngine;

[Game]
public sealed class PositionComponent : IComponent
{
  public int levelId;
  public int x;
  public int y;
}
