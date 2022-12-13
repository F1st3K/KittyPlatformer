using UnityEngine;

public class Enemy : Entity
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
}