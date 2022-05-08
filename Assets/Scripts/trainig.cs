using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainig : MonoBehaviour
{
    public GameObject _backButton;
    public GameObject _exitButton;
    public GameObject _headText;
    public GameObject _saveText;
    public GameObject _list;
    public GameObject _canText;
    public GameObject _vosklImage;
    public GameObject _vosklImage2;
    public GameObject _strelka;
    public GameObject _ramka;
    public GameObject _ramka2;
    public GameObject _nextButton;

    public void SetUp()
    {
        var _backButton = GameObject.Find("BackButton");
        var _exitButton = GameObject.Find("ExitButton");
        var _headText = GameObject.Find("HeadText");
        var _saveText = GameObject.Find("SaveText");
        var _list = GameObject.Find("List");
        var _canText = GameObject.Find("CanText");
        var  _vosklImage = GameObject.Find("VosklImage");
        var _vosklImage2 = GameObject.Find("VosklImage2");
        var _strelka = GameObject.Find("Strelka");
        var  _ramka = GameObject.Find("Ramka");
        var _ramka2 = GameObject.Find("Ramka2");
        var _nextButton = GameObject.Find("NextButton");
    }

    public void NextButton()
    {
        
    }
   
    
}
