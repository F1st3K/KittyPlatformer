using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace KittyPlatformer.Weapons
{
    public class Sword : RotatingWeapon
    {
        [SerializeField] private float range;
        
        public override void Fire(float power)
        {
            if (power <= 0)
                return;
            Collider2D [] attackArea =  CreateAttackArea(AttackPoint);
            foreach (var colliders in attackArea)
            {
                if (colliders.gameObject.TryGetComponent(out ILiving entity) &&
                    entity != (ILiving) Owner &&
                    IsCouldown)
                {
                    entity.GetDamage(Convert.ToInt32(Damage * power));
                }
            }
            IsCouldown = false;
            ReloadingTimer.Start();
        }

        private Collider2D[] CreateAttackArea(Vector2 position)
        {
            return Physics2D.OverlapCircleAll(position, range);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, innerRadius);
            Gizmos.DrawWireSphere(CreateAttackPoint(Vector2.right), range);
        }
    }
}