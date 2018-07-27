using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TurnService
{
  private readonly Contexts _contexts;

  class EntitySpeed
  {
    public readonly int entityId;
    public int speed;

    public EntitySpeed(int entityId, int speed)
    {
      this.entityId = entityId;
      this.speed = speed;
    }
  }

  private List<EntitySpeed> _entities = new List<EntitySpeed>();

  public TurnService(Contexts contexts)
  {
    _contexts = contexts;
    _entities.AddRange(new[]
    {
      new EntitySpeed(-1, 5),
      new EntitySpeed(-1, 15),
      new EntitySpeed(-1, 54),
      new EntitySpeed(-1, 51),
      new EntitySpeed(-1, 45),
    });
    _entities.Sort(new SpeedSortComparer());
  }

  public void RemoveEntity(int entityId)
  {
    _entities.RemoveAt(_entities.FindIndex(entity => entity.entityId == entityId));
  }

  public void AddEntity(int entityId, int speed)
  {
    var entitySpeed = new EntitySpeed(entityId, speed);
    var index = _entities.BinarySearch(entitySpeed, new SpeedIndexComparer(entitySpeed));
    _entities.Insert(index, entitySpeed);
    //    Debug.Log("index");
//    _entities.Insert(entityId);
  }

  class SpeedSortComparer : IComparer<EntitySpeed>
  {
    private readonly EntitySpeed _entitySpeed;

    public SpeedSortComparer(EntitySpeed entitySpeed)
    {
      _entitySpeed = entitySpeed;
    }

    public SpeedSortComparer()
    {
    }

    public int Compare(EntitySpeed x, EntitySpeed y)
    {
      if (x == null && y == null)
      {
        return 0;
      }
      
      if (x == null)
      {
        return 1;
      }

      if (y == null)
      {
        return -1;
      }
      
      if (x.speed > y.speed)
      {
        return -1;
      }

      if (x.speed < y.speed)
      {
        return 1;
      }

      return 0;
    }
  }


  class SpeedIndexComparer : IComparer<EntitySpeed>
  {
    private readonly EntitySpeed _entitySpeed;

    public SpeedIndexComparer(EntitySpeed entitySpeed)
    {
      _entitySpeed = entitySpeed;
    }

    public int Compare(EntitySpeed x, EntitySpeed y)
    {
      if (x.speed > y.speed)
      {
        return -1;
      }

      if (x.speed < y.speed)
      {
        return 1;
      }

      return 0;
    }
  }
}