using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class OperatedSpikes : Weapon
    {
        [SerializeField] private float radius;
        
        public override void Fire(float power)
        {
            Collider2D [] attackArea =  CreateAttackArea(AttackPoint);
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

        public override void Rotate(Vector2 direction)
        {
            
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