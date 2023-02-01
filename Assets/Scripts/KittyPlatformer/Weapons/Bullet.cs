using System;
using System.Timers;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int countCollisions;
        [SerializeField] private int timeLiver;
        [SerializeField] private float speed;
        
        private Vector2 _direction;
        private int _damage;
        private ILiving _owner;

        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;
        private Timer TimerLive;

        public int Damage => _damage;

        public int CountCollisions => countCollisions;

        public void SetDirection(Vector2 vector2)
        {
            if (vector2 == Vector2.zero)
                throw new ArgumentException();
            _direction = vector2;
        }
        
        public void SetDamage(int value)
        {
            if (value < 0)
                throw new ArgumentException();
            _damage = value;
        }

        public void SetOwner(ILiving value)
        {
            _owner = value;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            TimerLive = new Timer(timeLiver);
            TimerLive.Elapsed += ((sender, args) => countCollisions--);
        }

        private void Start()
        {
            _rigidbody2D.velocity = _direction * speed;
            TimerLive.Start();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other);
            if (other.gameObject.TryGetComponent(out ILiving entity) &&
                entity != _owner)
                entity.GetDamage(Damage);
            countCollisions--;
        }

        private void FixedUpdate()
        {
            if (countCollisions <= 0)
                Destroy(gameObject);
        }
    }
}