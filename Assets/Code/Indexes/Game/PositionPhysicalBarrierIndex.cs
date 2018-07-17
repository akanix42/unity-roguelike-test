using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[CustomEntityIndex(typeof(GameContext))]
public class PositionPhysicalBarrierIndex : EntityIndex<GameEntity, GameBoardElementPosition>
{
  public PositionPhysicalBarrierIndex(GameContext context) : base(
    "PositionPhysicalBarrierIndex",
    context.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Position, GameMatcher.PhysicalBarrier)), 
    (entity, component) =>
    {
      UnityEngine.Profiling.Profiler.BeginSample("PositionPhysicalBarrierIndex");

      var position = component is PositionComponent ? ((PositionComponent) component).value : entity.position.value;
//      var physicalBarrier = component is PhysicalBarrierComponent || entity.isPhysicalBarrier;
      var pos = GameBoardElementPosition.Create(position.levelId, position.x, position.y);
      UnityEngine.Profiling.Profiler.EndSample();
      return pos;
    })
  {
  }

  [EntityIndexGetMethod]
  public HashSet<GameEntity> GetPhysicalBarrierEntitiesWithPosition(GameBoardElementPosition index)
  {
    UnityEngine.Profiling.Profiler.BeginSample("GetPhysicalBarrierEntitiesWithPosition");
    var entities = GetEntities(index);
    UnityEngine.Profiling.Profiler.EndSample();

    return entities;
  }
}
//
//public struct PositionIndex : IEquatable<PositionIndex> {
//
//  public int levelId;
//  public int x;
//  public int y;
//
//  public PositionIndex(int levelId, int x, int y) {
//    this.levelId = levelId;
//    this.x = x;
//    this.y = y;
//  }
//
//  public bool Equals(PositionIndex other) {
//    return other.levelId == levelId && other.x == x && other.y == y;
//  }
//
//  public override bool Equals(object obj) {
//    if(obj == null || obj.GetType() != GetType() || obj.GetHashCode() != GetHashCode()) {
//      return false;
//    }
//
//    var other = (PositionIndex)obj;
//    return other.levelId == levelId && other.x == x && other.y == y;
//  }
//}