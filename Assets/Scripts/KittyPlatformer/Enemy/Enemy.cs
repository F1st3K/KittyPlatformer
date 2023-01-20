using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Enemy
{
    public sealed class Enemy : AttackerEntity
    {
        [SerializeField] private float visibilityRadius;
        [SerializeField] private float attackRadius;
        [SerializeField] private float patrolLength;

        private bool _isChase;
        private bool _isAttack;
        private Interactor _chasingCharacter;
        private Patrol _patrol;

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
                            _isAttack = true;
                            return;
                        }

                    _chasingCharacter = visibleCharacter;
                    _isChase = true;
                    _isAttack = false;
                    return;
                }

            _isChase = false;
            _isAttack = false;
        }

        private protected override void Awake()
        {
            base.Awake();
            _patrol = new Patrol(this, patrolLength);
        }
        
        private void Update()
        {
            
            if (_isChase)
            {
                var direction = _chasingCharacter.transform.position;
                Move(direction - transform.position, 1f);
                Rotate(direction);
                TakeAim(direction - transform.position);
            }

            if (_isAttack)
            {
                TakeAim(_chasingCharacter.transform.position - transform.position);
                //Attack(1f);
            }

            if (_isChase == false &&
                patrolLength > 0)
                _patrol.Run();
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