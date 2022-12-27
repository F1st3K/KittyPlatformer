using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public sealed class Enemy : LivingEntity, IAttacking
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        
        public void Attack(Vector2 direction, float power)
        {
            weapon.Fire(direction, power);
        }
    }
}