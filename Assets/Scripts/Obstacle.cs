using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private protected int damage;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Entity entity))
        {
            entity.GetDamage(damage);
        }
    }
}
