using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class AnchorForFanera : MonoBehaviour
{
    public Transform anchorForFanera;

   
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Fanera>(out var fanera))
        {
            fanera.transform.position = anchorForFanera.transform.position;
        }
    }
}
