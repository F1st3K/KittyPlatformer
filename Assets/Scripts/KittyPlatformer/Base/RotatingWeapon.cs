using System;
using Unity.VisualScripting;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class RotatingWeapon : Weapon
    {
        [SerializeField] private protected float innerRadius;
        
        private SpriteRenderer _sprite;
        private Vector2 rotationVector2;

        public override Vector2 RotationVector2 => rotationVector2;

        public override void Rotate(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;
            rotationVector2 = direction;
            AttackPoint = CreateAttackPoint(direction);
            _sprite.transform.position = new Vector3(AttackPoint.x, AttackPoint.y, _sprite.transform.position.z);
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
            Debug.Log(_sprite.transform.position + name);
            Rotate(Vector2.right);
        }
    }
}