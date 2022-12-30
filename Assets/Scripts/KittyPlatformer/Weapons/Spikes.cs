using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Spikes : Weapon
    {

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out ILiving entity) &&
                IsCouldown)
            {
                entity.GetDamage(Damage);
                IsCouldown = false;
                ReloadingTimer.Start();
            }
        }
    }
}