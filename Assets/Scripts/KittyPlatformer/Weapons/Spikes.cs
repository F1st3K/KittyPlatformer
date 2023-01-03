using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Spikes : Weapon
    {
        private bool _isEnabled;
        
        public override void Fire(float power)
        {
            _isEnabled = !_isEnabled;
        }

        public override void Rotate(Vector2 direction)
        {
            
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (_isEnabled &&
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