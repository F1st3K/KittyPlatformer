using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private protected int hitPoint;

    public virtual void GetDamage(int damage)
    {
        if (hitPoint - damage >= 0)
            hitPoint -= damage;
        else hitPoint = 0;
        Debug.Log(hitPoint + this.GetType().ToString());
    }

    private protected virtual void CheckAlive()
    {
        if(hitPoint <= 0)
            Destroy(this.gameObject);
    }
}