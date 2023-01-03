using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace KittyPlatformer.Weapons
{
    public class Spikes : Weapon
    {
        [SerializeField] private bool isEnabled;
        
        public override void Fire(float power)
        {
            isEnabled = !isEnabled;
        }

        public override void Rotate(Vector2 direction)
        {
            
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (isEnabled &&
                IsCouldown &&
                other.gameObject.TryGetComponent(out ILiving entity))
            {
                entity.GetDamage(Damage);
                IsCouldown = false;
                ReloadingTimer.Start();
            }
        }
    }
}