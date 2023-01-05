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

        private protected Rigidbody2D Rigidbody2D;
        private protected Collider2D Collider2D;
        private protected SpriteRenderer Sprite;

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
            Sprite.flipX = direction.x < 0.0f;
        }

        public void Jump(float mullForce)
        {
            if (mullForce < 0)
                throw new Exception("mullForce should be greater than zero");
            float currentJumpForce = jumpForce * mullForce;
            Rigidbody2D.velocity =  Vector2.up * currentJumpForce;
        }

        public bool CheckStayGround()
        {
            RaycastHit2D rayOnGround = Physics2D.Raycast(pointJump.position,
                                                         Vector2.down, 0);
            return rayOnGround.collider;
        }

        private protected virtual void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Collider2D = GetComponent<Collider2D>();
            Sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }
}