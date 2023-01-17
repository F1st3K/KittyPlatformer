using System;
using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace KittyPlatformer.Enemy
{
    public sealed class Enemy : AttackerEntity
    {
        [SerializeField] private float visibilityRadius;

        private bool _isChase;
        private Interactor chasingCharacter;

        private void LookAround()
        {
            Collider2D [] objs = Physics2D.OverlapCircleAll(transform.position, visibilityRadius);
            foreach (var entity in objs)
                if (entity.gameObject.TryGetComponent(out Interactor character))
                {
                    chasingCharacter = character;
                    _isChase = true;
                    return;
                }

            _isChase = false;
        }

        private void Update()
        {
            if (_isChase)
            {
                var direction = chasingCharacter.transform.position;
                Move(direction - transform.position, 1f);
                Rotate(direction);
            }
        }

        private void FixedUpdate()
        {
            LookAround();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, visibilityRadius);
        }
    }
}