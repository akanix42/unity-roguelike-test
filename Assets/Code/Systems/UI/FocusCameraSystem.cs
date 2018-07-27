using Entitas;
using UnityEngine;

public sealed class FocusCameraSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  
  public FocusCameraSystem(Contexts contexts)
  {
    _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.CameraTarget, GameMatcher.Position));
  }

  public void Execute()
  {
    foreach (var entity in _entities.GetEntities())
    {
        var position = entity.position.value;
        Camera.main.transform.position = new Vector3(position.x, position.y, Camera.main.transform.position.z);
    }
  }
}