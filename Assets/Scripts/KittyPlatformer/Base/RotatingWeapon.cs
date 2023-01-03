using System;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class RotatingWeapon : Weapon
    {
        [SerializeField] private float innerRadius;
        
        private SpriteRenderer _sprite;
        
        public override void Rotate(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;
            AttackPoint = CreateAttackPoint(direction);
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

        private protected override void Awake()
        {
            base.Awake();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, innerRadius);
            Gizmos.DrawWireSphere(CreateAttackPoint(Vector2.right), 0.01f);
        }
    }
}