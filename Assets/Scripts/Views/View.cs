
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener, IVisibleListener,
  IVisibleRemovedListener
{
  public virtual void Link(IEntity entity, IContext context)
  {
    gameObject.Link(entity, context);
    var e = (GameEntity) entity;
    e.AddPositionListener(this);
    e.AddDestroyedListener(this);
    e.AddVisibleListener(this);
    e.AddVisibleRemovedListener(this);
    
    var position = e.position.value;
    transform.localPosition = new Vector3(position.x, position.y);
  }

  public virtual void OnPosition(GameEntity entity, GameBoardElementPosition position)
  {
    transform.localPosition = new Vector3(position.x, position.y);
  }

  public virtual void OnDestroyed(GameEntity entity)
  {
    destroy();
  }

  protected void destroy()
  {
    gameObject.Unlink();
    Destroy(gameObject);
  }

  public virtual void OnVisible(GameEntity entity)
  {
    Debug.Log("On Visible");
    var spriteService = Contexts.sharedInstance.meta.spriteService.instance;
    var sprite = spriteService.GetSprite(entity.asciiSprite.value);
    GetComponent<SpriteRenderer>().sprite = sprite;
  }

  public void OnVisibleRemoved(GameEntity entity)
  {
    Debug.Log("On Not Visible");
    GetComponent<SpriteRenderer>().sprite = null;
  }

}