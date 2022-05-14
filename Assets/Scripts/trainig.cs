using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainig : MonoBehaviour
{
    public GameObject _panelStart;
    public GameObject _step1Panel;
    public GameObject _step2Panel;
    
   

     void Start()
    {
        var _panelStart = GameObject.Find("PanelStart");
        var _step1Panel = GameObject.Find("Step1Panel");
        var _step2Panel = GameObject.Find("Step2Panel");

        // _nextButton.onClick.AddListener(NextButtonOnClick());
    }

    // void NextButtonOnClick()
    // {
    // }
   
    
}
