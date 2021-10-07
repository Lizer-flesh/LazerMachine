using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform objectForMovement;
    public bool IsDownButton { get; private set; }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            var delta = new Vector3(0, -0.05f, 0);
            transform.position += delta;
            IsDownButton = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var delta = new Vector3(0, 0.05f, 0);
        transform.position += delta;
        IsDownButton = false;
    }
}