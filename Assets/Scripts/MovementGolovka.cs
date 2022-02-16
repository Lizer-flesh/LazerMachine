using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
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
        public RedButtonScript recordButton;
        public RedButtonScript playButton;

        [Range(0, 100)] public float speed = 50f;
        private float _calculatedSpeed;

        // public List<Vector3> coordinates = new List<Vector3>();

        private Queue<MovementPosition> _positionQueue = new Queue<MovementPosition>();

        private Direction _currentDirection;
        private Vector3 _currentMovementObjectPosition;
        private float length;
        public GameObject Lazer;
        private float timer;
        private Transform objectForMove;
        private Vector3 startPosition;
        private Vector3 newPosition;

        public int count_positions;

        // private int kolvo = 0;


        private void Update()
        {
            _calculatedSpeed = speed / 1000;
            Lazer.gameObject.SetActive(false);

            if (redButtonScript.Podnyal)
            {
                ExecuteUpMovement();
                ExecuteDownMovement();
                ExecuteRightMovement();
                ExecuteLeftMovement();


                if (recordButton.Podnyal)
                {
                    Lazer.gameObject.SetActive(true);
                    RecordPath();
                }

                if (playButton.Podnyal)
                {
                    if (_positionQueue.Count == 0)
                        return;
                    
                    PlayRecordsButton();
                }

            }
        }

        private void RecordPath()
        {
            if (upButton.IsDownButton || 
                downButton.IsDownButton || 
                leftButton.IsDownButton || 
                rightButton.IsDownButton)
                return;
            
                
            if (_positionQueue.Count != 0 )
            {
                var length = (_positionQueue.Last().position - _currentMovementObjectPosition).magnitude;

                if (length == 0)
                    return;

                var movementPosition = new MovementPosition(_currentDirection, length, _currentMovementObjectPosition);

                _positionQueue.Enqueue(movementPosition);
                 count_positions = _positionQueue.Count;

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

                if (palka.localPosition.x > 0.364f)
                    return;

                var delta = new Vector3(_calculatedSpeed, 0, 0);
                palka.position += delta;
                
                _currentDirection = Direction.Up;
                _currentMovementObjectPosition = palka.localPosition;
            }
        }

        private void ExecuteDownMovement()
        {
            var palka = downButton.objectForMovement;

            if (downButton.IsDownButton)
            {
                if (palka.localPosition.x < -0.242f)
                    return;
                
                var delta = new Vector3(-_calculatedSpeed, 0, 0);
                palka.position += delta;
            
                _currentDirection = Direction.Down;
                _currentMovementObjectPosition = palka.localPosition;
            }
                

            // var palka = downButton.objectForMovement;

            // if (palka.localPosition.x < -0.242f)
            //     return;

            // var delta = new Vector3(-_calculatedSpeed, 0, 0);
            // palka.position += delta;
            //
            // _currentDirection = Direction.Down;
            // _currentMovementObjectPosition = palka.localPosition;
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
                
                var loclPos = golovka.localPosition;
                 loclPos.z += length;
                golovka.localPosition = loclPos;
                
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

        private void PlayRecordsButton()
        {
            

            Debug.Log(timer);

            
            if (timer > 1)
            {
                _positionQueue.Dequeue();
                timer = 0;
            }
            
            if (timer == 0)
            {
                
                var element = _positionQueue.Peek();
                var lenght = element.length;
                var direction = element.direction;
                var delta = new Vector3(lenght, 0, 0);

                Debug.Log(direction);

                switch (direction)
                {
                    case Direction.Up:
                        delta = new Vector3(lenght, 0, 0);
                        objectForMove = upButton.objectForMovement;
                        break;
                
                    case Direction.Down:
                        delta = new Vector3(-lenght, 0, 0);
                        objectForMove = downButton.objectForMovement;
                        break;
                
                    case Direction.Left:
                        delta = new Vector3(0, 0, lenght);
                        objectForMove = leftButton.objectForMovement;
                        break;
                
                    case Direction.Right:
                        delta = new Vector3(0, 0, -lenght);
                        objectForMove = rightButton.objectForMovement;
                        break;
                }
                
                startPosition = objectForMove.transform.localPosition;
                newPosition = startPosition + delta;
            }


            timer += Time.deltaTime;

            objectForMove.transform.localPosition = Vector3.Lerp(startPosition, newPosition, timer);

            // var target = rightButton.objectForMovement;
            // // var palka = down.objectForMovement;
            //
            // if (saveButton.IsDownButton)
            // {
            //            // = Vector3.Lerp(transform.position, _positionQueue.Last().position, 1 );
            //            var next = _positionQueue.Dequeue();
            //            Debug.Log(next.position);
            //            target.transform.localPosition = Vector3.Lerp(transform.localPosition, next.position, 1);
            //            // palka.transform.localPosition = Vector3.Lerp(transform.localPosition, next.position, 1);
            // }
        }
    }
}