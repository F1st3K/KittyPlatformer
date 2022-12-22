using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    protected bool IsAlive => _health > 0;
    
    [SerializeField] private protected int maxHealth;
    [SerializeField] private Image fillHealthBar;
    
    private int _health;

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

    private protected void Start()
    {
        _health = maxHealth;
    }

    private protected void FixedUpdate()
    {
        UpdateHealthBar();
        CheckAlive();
    }

    private protected void UpdateHealthBar()
    {
        fillHealthBar.fillAmount = (float)_health / maxHealth;
    }
    
    private protected virtual void CheckAlive()
    {
        if(IsAlive == false)
            Destroy(this.gameObject);
    }
}