using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private protected int hitPoint;
    public virtual void GetDamage()
    {
        hitPoint--;
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}