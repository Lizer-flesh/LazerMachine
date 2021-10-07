// using UnityEngine;
// using UnityEngine.EventSystems;
//
// // public enum MoveButtons
// // {
// //     Up,
// //     Down,
// //     Right,
// //     Left
// // }
//
//
// public class ButtonScript : MonoBehaviour
// {
//     // public MoveButtons moveButton;
//     public RedButtonScript RedButtonScript;
//     public 
//     
//
//     // public bool _chek;
//     
//     public Transform Golovka;
//     public float Speed = 0.05f;
//     private bool chek;
//
//     private void Update()
//     {
//        GolovkaMovement();
//     }
//
//     private void GolovkaMovement()
//     {
//         if (CheckBounce())
//             return;
//         
//         var delta = Vector3.zero;
//         
//         if (chek)
//         {
//             switch (moveButton)
//             {
//                 case MoveButtons.Up:
//                     
//                     delta = new Vector3(Speed, 0, 0);
//                     break;
//                 
//                 case MoveButtons.Down:
//                     delta = new Vector3(-Speed, 0, 0);
//                     break;
//                 case MoveButtons.Left:
//                     delta = new Vector3(0, 0, Speed);
//                     break;
//                 case MoveButtons.Right:
//                     delta = new Vector3(0, 0, -Speed);
//                     break;
//             }
//             
//             
//             Golovka.position += delta;
//         }
//     }
//
//     private bool CheckBounce()
//     {
//         switch (moveButton)
//         {
//             case MoveButtons.Up:
//
//                 if (Golovka.localPosition.x > 0.33f)
//                 {
//                     return true;
//                 }
//                 break;
//             
//             case MoveButtons.Down:
//                 if (Golovka.localPosition.x < -0.24f)
//                 {
//                     return true;
//                 }
//                 break;
//             
//             case MoveButtons.Left:
//                 if (Golovka.localPosition.z > 0.48f)
//                 {
//                     return true;
//                 }
//                 break;
//             
//             case MoveButtons.Right:
//                 if (Golovka.localPosition.z < -0.5f)
//                 {
//                     return true;
//                 }
//                 break;
//         }
//
//         return false;
//
//     }
//
//     
// }