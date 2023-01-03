using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public class Obstacle : Entity, IAttacker
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        
        public void Attack(float power)
        {
            weapon.Fire(power);
        }
        
        public void TakeAim(Vector2 direction)
        {
            weapon.Rotate(direction);
        }
    }
}