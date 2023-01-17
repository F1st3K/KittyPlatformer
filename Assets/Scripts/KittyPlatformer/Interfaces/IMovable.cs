using UnityEngine;

namespace KittyPlatformer.Interfaces
{
    public interface IMovable
    {
        public float MoveSpeed { get; }
        
        public void Move(Vector3 direction,  float mullSpeed);
        public void Rotate(Vector3 direction);
    }
}