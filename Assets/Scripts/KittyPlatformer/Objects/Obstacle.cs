using Base;
using Interfaces;
using UnityEngine;

namespace Objects
{
    public class Obstacle : Entity, IAttacking
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        
        public void Attack(Vector2 direction, float power)
        {
            weapon.Fire(direction, power);
        }
    }
}