using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage(damage);
        }
    }
}
