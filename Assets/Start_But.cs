using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_But : MonoBehaviour
{
   public void onClick(string sceneName)
   {
      SceneManager.LoadScene(Sample);
   }
}
