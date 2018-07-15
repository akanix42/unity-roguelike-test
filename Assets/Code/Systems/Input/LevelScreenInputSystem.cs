using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public sealed class LevelScreenInputSystem : IInitializeSystem, IExecuteSystem, ICleanupSystem
{
  private readonly IGroup<GameEntity> _group;
  private readonly Contexts _contexts;
  private readonly IInputService _inputService;

  private InputEntity _inputManager;

  private readonly Dictionary<GameKey, Action> _commands;
  private readonly IGroup<GameEntity> _interactiveEntities;

  public LevelScreenInputSystem(Contexts contexts, IInputService inputService)
  {
    _contexts = contexts;
    _inputService = inputService;
    _group = contexts.game.GetGroup(GameMatcher.TargetedByUi);
    _interactiveEntities = contexts.game.GetGroup(GameMatcher.Interactive);

    _commands = new Dictionary<GameKey, Action>()
    {
      {new GameKey(KeyCode.I), () => ViewInventory()},
      {new GameKey(KeyCode.Space), () => MakeNpcAct()},
      {new GameKey(KeyCode.Keypad8), () => AddMoveCommand(GameDirections.Up)},
      {new GameKey(KeyCode.Keypad9), () => AddMoveCommand(GameDirections.UpRight)},
      {new GameKey(KeyCode.Keypad6), () => AddMoveCommand(GameDirections.Right)},
      {new GameKey(KeyCode.Keypad3), () => AddMoveCommand(GameDirections.DownRight)},
      {new GameKey(KeyCode.Keypad2), () => AddMoveCommand(GameDirections.Down)},
      {new GameKey(KeyCode.Keypad1), () => AddMoveCommand(GameDirections.DownLeft)},
      {new GameKey(KeyCode.Keypad4), () => AddMoveCommand(GameDirections.Left)},
      {new GameKey(KeyCode.Keypad7), () => AddMoveCommand(GameDirections.UpLeft)},
      {new GameKey(KeyCode.Keypad5), () => AddMoveCommand(GameDirections.Up)},
    };
  }

  private void MakeNpcAct()
  {
    foreach (var gameEntity in _contexts.game.GetGroup(GameMatcher.AI))
    {
      gameEntity.isActing = true;
    }
  }

  public void Initialize()
  {
    _inputManager = _contexts.input.inputManagerEntity;
  }

  public void Execute()
  {
    if (
      !_contexts.game.isMainGameScreen
      || !_inputManager.hasKeysHeld
      || !_inputManager.keysHeld.keys.Any())
    {
      return;
    }

    var gameKey = _inputManager.keysHeld.keys.First(_commands.ContainsKey);
    _commands[gameKey]();
  }

  private void AddMoveCommand(IntVector2 direction)
  {
    foreach (var interactiveEntity in _interactiveEntities)
    {
      interactiveEntity.ReplaceAttackMoveCommand(direction);
    }
  }

  private void ViewInventory()
  {
    foreach (var interactiveEntity in _interactiveEntities)
    {
      interactiveEntity.hasViewInventoryCommand = true;
    }
  }
  
  public void Cleanup()
  {
    if (_contexts.game.isMainGameScreen)
    {
      _inputService.SetAvailableKeys(_commands.Keys.Select(key => key.keyCode).ToList());
    }
  }
}

public enum GameDirection
{
  Down,
  DownLeft,
  DownRight,
  Left,
  Right,
  Up,
  UpLeft,
  UpRight,
}

public static class GameDirections
{
  public static readonly IntVector2 Down = new IntVector2 {x = 0, y = -1};
  public static readonly IntVector2 DownLeft = new IntVector2 {x = -1, y = -1};
  public static readonly IntVector2 DownRight = new IntVector2 {x = 1, y = -1};
  public static readonly IntVector2 Left = new IntVector2 {x = -1, y = 0};
  public static readonly IntVector2 Right = new IntVector2 {x = 1, y = 0};
  public static readonly IntVector2 Up = new IntVector2 {x = 0, y = 1};
  public static readonly IntVector2 UpLeft = new IntVector2 {x = -1, y = 1};
  public static readonly IntVector2 UpRight = new IntVector2 {x = 1, y = 1};
}