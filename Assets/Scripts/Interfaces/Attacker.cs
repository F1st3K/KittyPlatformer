using UnityEngine;

namespace Interfaces
{
    public abstract class Attacker : LivingEntity, IAttacking
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        
        public void Attack()
        {
            weapon.Fire();
        }
    }
}