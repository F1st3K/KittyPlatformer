﻿using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Interfaces
{
    public abstract class Controllable : MonoBehaviour, IMovable, IJumper, IAttacking
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Weapon weapon;
        
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _sprite;
        
        public float MoveSpeed => speed;
        public float JumpForce => jumpForce;
        public IWeaponer Weapon => weapon;

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
            return true;
        }
        
        public void Attack()
        {
            weapon.Fire();
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }
    }
}