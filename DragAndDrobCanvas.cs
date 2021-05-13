using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrobCanvas : EventTrigger
{
    private bool dragging;
  
    private void Start()
    {
        
    }
    public void Update()
    {
        if (dragging == true)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
      
    }
}
