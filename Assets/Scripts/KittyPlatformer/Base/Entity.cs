using System;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Base
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public abstract class Entity : MonoBehaviour, IMovable, IJumper
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform pointJump;

        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;
        private SpriteRenderer _sprite;

        public float MoveSpeed => speed;
        public float JumpForce => jumpForce;
        
        public void Move(Vector3 direction, float mullSpeed)
        {
            if (mullSpeed < 0)
                throw new Exception("mullSpeed should be greater than zero");
            float currentSpeed = speed * mullSpeed;
            Vector3 position = transform.position;
            position = Vector3.MoveTowards(position,
                                            position+direction,
                                            currentSpeed*Time.deltaTime);
            transform.position = position;
            _sprite.flipX = direction.x < 0.0f;
        }

        public void Jump(float mullForce)
        {
            if (mullForce < 0)
                throw new Exception("mullForce should be greater than zero");
            float currentJumpForce = jumpForce * mullForce;
            _rigidbody2D.velocity =  Vector2.up * currentJumpForce;
        }

        public bool CheckStayGround()
        {
            Debug.Log(-_collider2D.transform.position.y + _collider2D.bounds.min.y);
            RaycastHit2D rayOnGround = Physics2D.Raycast(pointJump.position,
                                                         Vector2.down, 0);
            return rayOnGround.collider;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }
}