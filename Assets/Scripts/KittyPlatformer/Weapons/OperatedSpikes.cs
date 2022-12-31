using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class OperatedSpikes : Weapon
    {
        [SerializeField] private float radius;
        
        public override void Fire(Vector2 direction, float power)
        {
            Collider2D [] attackArea =  CreateAttackArea();
            foreach (var colliders in attackArea)
            {
                if (colliders.gameObject.TryGetComponent(out ILiving entity))
                    entity.GetDamage(Damage);
            }
        }

        private Collider2D[] CreateAttackArea()
        {
            return Physics2D.OverlapCircleAll(transform.position, radius);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}