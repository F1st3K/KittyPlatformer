using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class OperatedSpikes : Weapon
    {
        [SerializeField] private float radius;
        
        public override void Fire(Vector2 direction, float power)
        {
            Collider2D [] attackArea =  CreateAttackArea(transform.position);
            foreach (var colliders in attackArea)
            {
                if (colliders.gameObject.TryGetComponent(out ILiving entity) &&
                    entity != (ILiving)Owner &&
                    IsCouldown)
                {
                    entity.GetDamage(Convert.ToInt32(Damage * power));
                    IsCouldown = false;
                    ReloadingTimer.Start();
                }
            }
        }

        private Collider2D[] CreateAttackArea(Vector2 position)
        {
            return Physics2D.OverlapCircleAll(position, radius);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}