using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityTemplateProjects
{
    public class MovementGolovka : MonoBehaviour
    {
        public RedButtonScript redButtonScript;
        public MovementButton upButton;
        public MovementButton downButton;
        public MovementButton rightButton;
        public MovementButton leftButton;
        
        public float Speed = 0.05f;


        private void Update()
        {
            if (redButtonScript.Podnyal)
            {
                ExecuteUpMovement();
                ExecuteDownMovement();
                ExecuteRightMovement();
                ExecuteLeftMovement();
            }
        }

        private void ExecuteUpMovement()
        {
            if (upButton.IsDownButton)
            {
                var palka = upButton.objectForMovement;

                if (palka.localPosition.x > 0.35f)
                    return;

                var delta = new Vector3(Speed, 0, 0);
                palka.position += delta;
            }
        }

        private void ExecuteDownMovement()
        {
            if (!downButton.IsDownButton)
                return;

            var palka = downButton.objectForMovement;
            
            if (palka.localPosition.x < -0.242f)
                return;
            
            var delta = new Vector3(-Speed, 0, 0);
            palka.position += delta;
        }

        private void ExecuteRightMovement()
        {
            if (!rightButton.IsDownButton)
                return;

            var golovka = rightButton.objectForMovement;
            
            if (golovka.localPosition.z < -0.46f)
                return;
            
            var delta = new Vector3(0, 0, -Speed);
            golovka.position += delta;
        }

        private void ExecuteLeftMovement()
        {
            if (!leftButton.IsDownButton)
                return;

            var golovka = leftButton.objectForMovement;
            
            if (golovka.localPosition.z > 0.5f)
                return;
            
            var delta = new Vector3(0, 0, Speed);
            golovka.position += delta;
        }
    }
}