using System;
using System.Diagnostics;
using System.Linq;
using Entitas;
using UnityEngine;
using Debug = UnityEngine.Debug;

public sealed class DebugStopActingSystem : IExecuteSystem
{
  private readonly IGroup<GameEntity> _entities;
  private float _timeToEnd;
  private float TimeLimit = 30f;
  private bool _isActing = false;
  private Stopwatch _stopwatch = new Stopwatch();

  public DebugStopActingSystem(Contexts contexts)
  {
    Debug.Log("DEBUG system DebugStopActingSystem enabled! Disable when finished debugging!!!");
    _entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.AI, GameMatcher.Acting));
  }

  public void Execute()
  {
    var entities = _entities.GetEntities();
    if (entities.Any() && !_isActing)
    {
      _isActing = true;
      _timeToEnd = Time.time + TimeLimit;
      _stopwatch.Restart();
    }

    if (!_isActing)
      return;
    
    var elapsedTime = _stopwatch.Elapsed.TotalSeconds;
    if (elapsedTime < TimeLimit) //|| Time.time < _timeToEnd)
      return;

    if (entities.Any())
    {
      var turns = entities[0].turnCount.value;
      Debug.Log($"Turns: {turns}; TPS: {Math.Round((float) turns / elapsedTime, 2)}");
      foreach (var entity in entities)
      {
        entity.isActing = false;
        entity.ReplaceTurnCount(0);
      }
    }

    _isActing = false;
    _stopwatch.Stop();
  }
}