using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineDraw;

    private void Start()
    {
        lineDraw.startWidth = 0.2f;
        lineDraw.endWidth = 0.2f;
        lineDraw.positionCount = 0;
    }
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);
        //    Debug.Log(currentPoint);
        //    lineDraw.positionCount++;
        //    lineDraw.SetPosition(lineDraw.positionCount - 1, currentPoint);
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    lineDraw.positionCount=0;
        //}
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);
                    Debug.Log(currentPoint);
                    lineDraw.positionCount++;
                    lineDraw.SetPosition(lineDraw.positionCount - 1, currentPoint);
                    break;
                case TouchPhase.Ended:
                    lineDraw.positionCount = 0;
                    break;
            }
        }
    }
    
    private Vector3 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector3 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
