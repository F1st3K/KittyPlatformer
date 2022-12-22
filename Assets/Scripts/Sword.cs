using System;
using UnityEngine;

class Sword : Weapon
{
    [SerializeField] private float radius;
    [SerializeField] private Transform attackPoint;

    public override void Attack(Vector2 vector, float power)
    {
        Collider2D [] attackArea =  CreateAttackArea();
        foreach (var colliders in attackArea)
        {
            if (colliders.gameObject.TryGetComponent(out Enemy enemy))
                enemy.GetDamage(damage);
        }
    }

    private Collider2D[] CreateAttackArea()
    {
        return Physics2D.OverlapCircleAll(attackPoint.position, radius);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}