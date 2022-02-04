using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForButtons : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public bool IsRaisedButton { get; private set;}
    public float deltaY;
    public bool SelfUp;
    public Transform objectForMovement;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SelfUp)
        {
            OneStepButton();
        }
        else
        {
            TwoStepButton();
        }
       
    }

    public void TwoStepButton()
    {
        var delta = new Vector3(0, deltaY, 0);
        delta = IsRaisedButton ? delta : -delta;
        IsRaisedButton = !IsRaisedButton;
        transform.localPosition += delta;
    }

    public void OneStepButton()
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
}
