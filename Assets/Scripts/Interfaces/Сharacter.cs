using UnityEngine;

namespace Interfaces
{
    public sealed class Сharacter : LivingEntity, IAttacking
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        
        public void Attack(Vector2 direction, float power)
        {
            weapon.Fire(direction, power);
        }
    }
}