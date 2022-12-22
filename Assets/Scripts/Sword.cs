using UnityEngine;

class Sword : Weapon
{
    [SerializeField] private float radius;

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
        return Physics2D.OverlapCircleAll(WeaponSprite.transform.position, radius);
    }
}