using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MachineMovement : MonoBehaviour
{
    [SerializeField]private ForButtons upButton;
    [SerializeField]private ForButtons downButton;
    [SerializeField]private ForButtons leftButton;
    [SerializeField]private ForButtons rightButton;
    [SerializeField]private ForButtons powerButton;
    
    
    private Transform _objectToMove;
    private Direction _currentDirection;
    private float _calculatedSpeed;
    [SerializeField]private GameObject _lazerStick;
    
    [Range(0, 100)] public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        _lazerStick.SetActive(false);
        upButton.OnClick+= value =>
        {
            _lazerStick.SetActive(value);
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        _calculatedSpeed = speed / 1000; 
       
    }
    
    private void UpButtonMovement()
    {
        var guideBeam = upButton.objectForMovement;
        
        if (upButton.IsRaisedButton)
        {
            if (guideBeam.localPosition.x > 0.364f)
                return;
        }

    }

    private void DownButtonMovement()
    {
        var guideBeam = downButton.objectForMovement;
        
        if (guideBeam.localPosition.x < -0.258f)
            return;
    }

    private void LeftButtonMovement()
    {
        var lazerHead = leftButton.objectForMovement;
        
        if (lazerHead.localPosition.z > 0.551f)
            return;
    }

    private void RightButtonMovement()
    {
        var lazerHead = rightButton.objectForMovement;
        
        if (lazerHead.localPosition.z < -0.566f)
            return;
    }

}


