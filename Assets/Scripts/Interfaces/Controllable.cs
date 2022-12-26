using UnityEngine;

namespace Interfaces
{
    public abstract class Controllable : MonoBehaviour, IMovable, IJumpable, IAttacking
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Weapon weapon;
        
        public float MoveSpeed => speed;
        public float JumpForce => speed;
        public IWeaponer Weapon => weapon;

        public void Move()
        {
            
        }
        
        public void Jump()
        {
            
        }
        
        public void Attack()
        {
            weapon.Fire();
        }
        
    }
}