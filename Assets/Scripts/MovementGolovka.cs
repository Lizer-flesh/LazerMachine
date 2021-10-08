using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace UnityTemplateProjects
{
    public class MovementGolovka : MonoBehaviour
    {
        public RedButtonScript redButtonScript;
        public MovementButton upButton;
        public MovementButton downButton;
        public MovementButton rightButton;
        public MovementButton leftButton;

        [Range(0, 100)] public float speed = 50f;
        private float _calculatedSpeed;

        // public List<Vector3> coordinates = new List<Vector3>();

        private Queue<MovementPosition> _positionQueue = new Queue<MovementPosition>();

        private Direction _currentDirection;
        private Vector3 _currentMovementObjectPosition;
        // private int kolvo = 0;


        private void Update()
        {
            _calculatedSpeed = speed / 1000;

            if (redButtonScript.Podnyal)
            {
                ExecuteUpMovement();
                ExecuteDownMovement();
                ExecuteRightMovement();
                ExecuteLeftMovement();

                RecordPath();
            }
        }

        private void RecordPath()
        {
            if (upButton.IsDownButton || 
                downButton.IsDownButton || 
                leftButton.IsDownButton || 
                rightButton.IsDownButton)
                return;
            
                
            if (_positionQueue.Count != 0)
            {
                var length = (_positionQueue.Last().position - _currentMovementObjectPosition).magnitude;

                if (length == 0)
                    return;

                var movementPosition = new MovementPosition(_currentDirection, length, _currentMovementObjectPosition);

                _positionQueue.Enqueue(movementPosition);

                Debug.Log($"POS {_currentMovementObjectPosition}, DIR {_currentDirection}, LEN {length}");
            }
            else
            {
                var length = 0f;

                var movementPosition = new MovementPosition(_currentDirection, length, _currentMovementObjectPosition);

                _positionQueue.Enqueue(movementPosition);
                
                Debug.Log($"POS {_currentMovementObjectPosition}, DIR {_currentDirection}, LEN {length}");

            }
        }

        private void ExecuteUpMovement()
        {
            if (upButton.IsDownButton)
            {
                var palka = upButton.objectForMovement;

                if (palka.localPosition.x > 0.35f)
                    return;

                var delta = new Vector3(_calculatedSpeed, 0, 0);
                palka.position += delta;
                
                _currentDirection = Direction.Up;
                _currentMovementObjectPosition = palka.localPosition;
            }
        }

        private void ExecuteDownMovement()
        {
            if (!downButton.IsDownButton)
                return;

            var palka = downButton.objectForMovement;

            if (palka.localPosition.x < -0.242f)
                return;

            var delta = new Vector3(-_calculatedSpeed, 0, 0);
            palka.position += delta;
            
            _currentDirection = Direction.Down;
            _currentMovementObjectPosition = palka.localPosition;
        }

        private void ExecuteRightMovement()
        {
            var golovka = rightButton.objectForMovement;

            if (rightButton.IsDownButton)
            {
                if (golovka.localPosition.z < -0.46f)
                    return;

                var delta = new Vector3(0, 0, -_calculatedSpeed);
                golovka.position += delta;

                _currentDirection = Direction.Right;
                _currentMovementObjectPosition = golovka.localPosition;

            }
            // else
            // {
            //     RecordPath(Direction.Right, golovka.localPosition);
            // }
        }

        private void ExecuteLeftMovement()
        {
            var golovka = leftButton.objectForMovement;

            if (leftButton.IsDownButton)
            {
                if (golovka.localPosition.z > 0.5f)
                    return;

                var delta = new Vector3(0, 0, _calculatedSpeed);
                golovka.position += delta;
                
                _currentDirection = Direction.Left;
                _currentMovementObjectPosition = golovka.localPosition;
                
                // var loclPos = golovka.localPosition;
                // loclPos.z += Length;
                // golovka.localPosition == loclPos;
                
                //интерполяция а именно Vector.Lerp
                //Time.time
                //Time.deltatime
                
                //Vector3.Lerp(yy, hh, 0.5)
            }
            // else
            // {
            //     RecordPath(Direction.Left, golovka.localPosition);
            // }
        }
    }
}