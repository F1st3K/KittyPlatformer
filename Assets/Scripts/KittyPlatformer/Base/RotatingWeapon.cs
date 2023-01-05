using System;
using Unity.VisualScripting;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class RotatingWeapon : Weapon
    {
        [SerializeField] private protected float innerRadius;
        
        private SpriteRenderer _sprite;
        public Vector2 RotationVector2 { get; private set; }

        public override void Rotate(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;
            RotationVector2 = direction;
            AttackPoint = CreateAttackPoint(direction);
            _sprite.transform.position = AttackPoint;
            _sprite.transform.rotation = CreateAttackAngle(direction);
            _sprite.flipX = _sprite.transform.rotation.z > 0;
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
            point += (Vector2)this.GameObject().transform.position;
            return point;
        }
        
        private protected Quaternion CreateAttackAngle(Vector2 direction) 
            => Quaternion.Euler(0, 0, (float)(Math.Atan2(direction.x, direction.y) * -180 / Math.PI));

        private protected override void Awake()
        {
            base.Awake();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            Rotate(Vector2.right);
        }
    }
}