using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpritesService : ISpritesService
{
  private readonly Dictionary<string, Sprite> _sprites;

  public SpritesService()
  {
//    _sprites = Resources.LoadAll<Sprite>("DejaVuSansMono").ToDictionary(sprite => sprite.name);
    _sprites = Resources.LoadAll<Sprite>("Text").ToDictionary(sprite => sprite.name);
  }

  public Sprite GetSprite(string name)
  {
    return _sprites[name];
  }
}