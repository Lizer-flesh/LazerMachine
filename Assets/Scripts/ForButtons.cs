using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsRaisedButton { get; private set; }
    public float deltaY;
    public bool SelfUp;
    public Transform objectForMovement;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        TwoStepButton();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!SelfUp)
            return;
        
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        TwoStepButton();
    }
    public void TwoStepButton()
    {
        var delta = new Vector3(0, deltaY, 0);
        delta = IsRaisedButton ? delta : -delta;
        transform.position += delta;
        IsRaisedButton = !IsRaisedButton;
    }
    
}