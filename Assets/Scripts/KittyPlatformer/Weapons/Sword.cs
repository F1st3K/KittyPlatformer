using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace KittyPlatformer.Weapons
{
    public class Sword : Weapon
    {
        [SerializeField] private float innerRadius;
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
                    IsCouldown = false;
                    ReloadingTimer.Start();
                }
            }
        }

        public override void Rotate(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;
            AttackPoint = CreateAttackPoint(direction);
        }

        private Collider2D[] CreateAttackArea(Vector2 position)
        {
            return Physics2D.OverlapCircleAll(position, range);
        }

        private Vector2 CreateAttackPoint(Vector2 direction)
        {
            if (direction == Vector2.zero)
                throw new InvalidOperationException();
            double d = Math.Sqrt(direction.x * direction.x + direction.y * direction.y);
            var point = new Vector2
            {
                x = Convert.ToSingle(direction.x * innerRadius / d),
                y = Convert.ToSingle(direction.y * innerRadius / d)
            };
            point += (Vector2)transform.position;
            return point;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, innerRadius);
            Gizmos.DrawWireSphere(CreateAttackPoint(Vector2.right), range);
        }
    }
}