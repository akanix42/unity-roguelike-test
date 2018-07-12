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

  private readonly Dictionary<GameKey, int> _commands = new Dictionary<GameKey, int>()
  {
    {new GameKey(KeyCode.I), GameComponentsLookup.ViewInventoryCommand},
    {new GameKey(KeyCode.U), GameComponentsLookup.ViewInventoryCommand},
    {new GameKey(KeyCode.Keypad8), GameComponentsLookup.DirectionUpCommand},
  };

  public LevelScreenInputSystem(Contexts contexts, IInputService inputService)
  {
    _contexts = contexts;
    _inputService = inputService;
    _group = contexts.game.GetGroup(GameMatcher.TargetedByUi);
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
    var commandIndex = _commands[gameKey];

    foreach (var gameEntity in _group)
    {
      gameEntity.ReplaceComponent(commandIndex,
        (IComponent) Activator.CreateInstance(GameComponentsLookup.componentTypes[commandIndex]));
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