using UnityEngine;

namespace Interfaces
{
    public interface IMovable
    {
        public float MoveSpeed { get; }
        
        public void Move(Vector3 direction,  float mullSpeed);
    }
}