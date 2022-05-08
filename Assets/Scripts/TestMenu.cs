using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestMenu : MonoBehaviour
{
    public void TestMenu_Exit()
    {
        SceneManager.LoadScene(1);
    }

}
