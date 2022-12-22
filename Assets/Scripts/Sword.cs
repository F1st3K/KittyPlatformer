using UnityEngine;

class Sword : Weapon
{
    [SerializeField] private float radius;
    public override void Attack(Vector2 vector, float power)
    {
        base.Attack(vector, power);
        Collider2D attackArea =  CreateAttackArea();
    }

    private Collider2D CreateAttackArea()
    {
        return Physics2D.OverlapCircle(transform.position, radius);
    }
}