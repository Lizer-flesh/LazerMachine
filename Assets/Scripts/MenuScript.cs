using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Menu_Start()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu_Exit()
    {
        Application.Quit();
    }
}
