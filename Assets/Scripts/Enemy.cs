using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private int damage;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Hero hero))
        {
            hero.GetDamage(damage);
        }
    }
}