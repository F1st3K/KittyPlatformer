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
        [SerializeField] private float attackRadius;

        private bool _isChase;
        private Interactor chasingCharacter;

        private void LookAround()
        {
            Collider2D [] visibleCircle = Physics2D.OverlapCircleAll(transform.position, visibilityRadius);
            Collider2D [] attackingCircle = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            foreach (var visibleEntity in visibleCircle)
                if (visibleEntity.gameObject.TryGetComponent(out Interactor visibleCharacter))
                {
                    foreach (var attackingEntity in attackingCircle)
                        if (attackingEntity.gameObject.TryGetComponent(out Interactor attackingCharacter))
                        {
                            visibleCharacter = attackingCharacter;
                            _isChase = false;
                            return;
                        }

                    chasingCharacter = visibleCharacter;
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
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
    }
}