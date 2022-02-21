using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsRaisedButton { get; private set; }
    public float deltaY;
    public bool SelfUp;
    public Transform objectForMovement;
    //public event Action<bool> OnClick;

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
        //OnClick?.Invoke(!IsRaisedButton);
        var delta = new Vector3(0, deltaY, 0);
        delta = IsRaisedButton ? delta : -delta;
        transform.position += delta;
        IsRaisedButton = !IsRaisedButton;
    }
}