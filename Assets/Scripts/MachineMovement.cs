using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MachineMovement : MonoBehaviour
{
    [SerializeField] private ForButtons upButton;
    [SerializeField] private ForButtons downButton;
    [SerializeField] private ForButtons leftButton;
    [SerializeField] private ForButtons rightButton;
    [SerializeField] private ForButtons powerButton;
    [SerializeField] private ForButtons stopButton;


    private Transform _objectToMove;
    private Direction _currentDirection;
    private float _calculatedSpeed;
    [SerializeField] private GameObject _lazerStick;

    [Range(0, 100)] public float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        _lazerStick.SetActive(false);
        _calculatedSpeed = speed / 1000;
        // upButton.OnClick+= value =>
        // {
        //     _lazerStick.SetActive(value);
        // };
    }

    // Update is called once per frame
    void Update()
    {
        if (stopButton.IsRaisedButton)
            return;
        
        if (!powerButton.IsRaisedButton)
            return;

        UpButtonMovement();
        DownButtonMovement();
        LeftButtonMovement();
        RightButtonMovement();
    }

    private void UpButtonMovement()
    {
        var guideBeam = upButton.objectForMovement;

        if (!upButton.IsRaisedButton)
            return;

        if (guideBeam.localPosition.x > 0.364f)
            return;

        var delta = new Vector3(_calculatedSpeed, 0, 0);
        guideBeam.position += delta;
    }

    private void DownButtonMovement()
    {
        var guideBeam = downButton.objectForMovement;

        if (!downButton.IsRaisedButton)
            return;

        if (guideBeam.localPosition.x < -0.258f)
            return;

        var delta = new Vector3(-_calculatedSpeed, 0, 0);
        guideBeam.position += delta;
    }

    private void LeftButtonMovement()
    {
        var lazerHead = leftButton.objectForMovement;

        if (!leftButton.IsRaisedButton)
            return;

        if (lazerHead.localPosition.z > 0.551f)
            return;

        var delta = new Vector3(0, 0, _calculatedSpeed);
        lazerHead.position += delta;
    }

    private void RightButtonMovement()
    {
        var lazerHead = rightButton.objectForMovement;

        if (!rightButton.IsRaisedButton)
            return;

        if (lazerHead.localPosition.z < -0.566f)
            return;

        var delta = new Vector3(0, 0, -_calculatedSpeed);
        lazerHead.position += delta;
    }
}