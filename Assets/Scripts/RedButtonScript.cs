using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedButtonScript : MonoBehaviour, IPointerClickHandler
{
    public bool Podnyal { get; private set; }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Podnyal == false)
        {
            var delta = new Vector3(0, -0.05f, 0);
            transform.localPosition += delta;
            Podnyal = true;
            
        }

        else
        {
            var delta = new Vector3(0, 0.05f, 0);
            transform.localPosition += delta;
            Podnyal = !Podnyal;
            
        }
    }
}

