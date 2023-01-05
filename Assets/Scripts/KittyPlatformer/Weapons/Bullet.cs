using System;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private int _countCollisions;
        private ILiving _owner;

        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;

        public int Damage => _damage;

        public int CountCollisions => _countCollisions;
        
        public void SetDamage(int value)
        {
            if (value < 0)
                throw new ArgumentException();
            _damage = value;
        }

        public void SetCountCollisions(int value)
        {
            if (value < 0)
                throw new ArgumentException();
            _countCollisions = value;
        }
        
        public void SetOwner(ILiving value)
        {
            _owner = value;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }

        private void Start()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out ILiving entity) &&
                entity != _owner)
                entity.GetDamage(Damage);
            _countCollisions--;
        }

        private void Update()
        {
            if (_countCollisions <= 0)
                Destroy(gameObject);
        }
    }
}