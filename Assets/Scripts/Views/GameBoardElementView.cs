//using DG.Tweening;


using UnityEngine;

public class GameBoardElementView : View
{
  public Sprite sprite
  {
    get { return _sprite; }
    set
    {
      _sprite = value;
      spriteRenderer.sprite = sprite;
    }
  }

  private SpriteRenderer spriteRenderer
  {
    get
    {
      if (!_spriteRenderer)
      {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      }

      return _spriteRenderer;
    }
  }

  public float destroyDuration;
  private Sprite _sprite;
  private SpriteRenderer _spriteRenderer;

  public override void OnPosition(GameEntity entity, GameBoardElementPosition position)
  {
    Debug.Log($"Set Position: {position.x},{position.y}");
//        var isTopRow = value.y == Contexts.sharedInstance.game.gameBoard.rows - 1;
//        if (isTopRow) {
//            transform.localPosition = new Vector3(value.x, value.y + 1);
//        }
    transform.position = new Vector3(position.x, position.y);
//        transform.DOMove(new Vector3(value.x, value.y, 0f), 0.3f);
  }

  public override void OnDestroyed(GameEntity entity)
  {
//        var color = spriteRenderer.color;
//        color.a = 0f;
//      spriteRenderer.material.DOColor(color, destroyDuration);
//        gameObject.transform
//            .DOScale(Vector3.one * 1.5f, destroyDuration)
//            .OnComplete(destroy);
    destroy();
  }

//  
//  public override void OnVisible(GameEntity entity)
//  {
//    Debug.Log("On Visible 2");
//    var spriteService = Contexts.sharedInstance.meta.spriteService.instance;
//    var sprite = spriteService.GetSprite(entity.asciiSprite.value);
//    GetComponent<SpriteRenderer>().sprite = sprite;
//  }
}