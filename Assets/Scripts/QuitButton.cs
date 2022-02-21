using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTemplateProjects
{
    public class QuitButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(Application.Quit);
        }
    }
}