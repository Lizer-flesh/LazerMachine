using UnityEngine;

namespace UnityTemplateProjects
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    public enum MovementObject
    {
        Golovka,
        Palka
    }
    
    public struct MovementPosition
    {
        public Direction direction;
        public float length;
        public Vector3 position;

        public MovementPosition(Direction direction, float length, Vector3 position)
        {
            this.direction = direction;
            this.length = length;
            this.position = position;
        }
    }
}