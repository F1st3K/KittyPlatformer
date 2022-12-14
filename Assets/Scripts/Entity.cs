using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private protected int hitPoint;

    public virtual void GetDamage(int damage)
    {
        hitPoint -= damage;
        Debug.Log(hitPoint + this.GetType().ToString());
    }

    private protected virtual void CheckAlive()
    {
        if(hitPoint <= 0)
            Destroy(this.gameObject);
    }
}