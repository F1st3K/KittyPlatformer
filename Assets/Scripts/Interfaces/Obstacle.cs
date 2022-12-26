using UnityEngine;

namespace Interfaces
{
    public class Obstacle : Entity, IAttacking
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        
        public void Attack()
        {
            weapon.Fire();
        }
        
    }
}