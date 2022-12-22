using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Entity : MonoBehaviour
{
    protected bool IsAlive => _health > 0;
    
    [SerializeField] private protected int maxHealth;

    private int _health;

    private protected void Start()
    {
        _health = maxHealth;
    }

    public virtual void GetDamage(int value)
    {
        if (_health - value >= 0)
            _health -= value;
        else _health = 0;
        Debug.Log(_health + this.GetType().ToString());
    }
    
    public virtual void GetHealth(int value)
    {
        if (_health + value <= maxHealth)
            _health += value;
        else _health = maxHealth;
        Debug.Log(_health + this.GetType().ToString());
    }

    private protected virtual void CheckAlive()
    {
        if(IsAlive == false)
            Destroy(this.gameObject);
    }
}