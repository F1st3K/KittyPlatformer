using System;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class RotatingWeapon : Weapon
    {
        [SerializeField] private protected float innerRadius;
        
        private SpriteRenderer _sprite;
        
        public override void Rotate(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;
            AttackPoint = CreateAttackPoint(direction);
            _sprite.transform.position = AttackPoint;
            _sprite.transform.rotation = Quaternion.Euler(0, 0, CreateAttackAngle(direction));
        }
        
        private protected Vector2 CreateAttackPoint(Vector2 direction)
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
        
        private float CreateAttackAngle(Vector2 direction) 
            => (float)(Math.Atan2(direction.x, direction.y) * -180 / Math.PI);

        private protected override void Awake()
        {
            base.Awake();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }
}