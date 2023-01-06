using System;
using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class Interactor : AttackerEntity, IStateChanger, ICoinCollector, IManaCollerctor

    {
    [SerializeField] private int countCoin;
    [SerializeField] private int countMana;

    public int CountCoin => countCoin;
    public int CountMana => countMana;

    public IStateVariable StateVariableEntity { get; private set; }

    public void SetSwitchingEntity(IStateVariable obj)
    {
        StateVariableEntity = obj;
    }

    public void ToggleCurrentSwitchingEntity()
    {
        if (StateVariableEntity.IsActivate)
            StateVariableEntity.DeActivate();
        else StateVariableEntity.Activate();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IItem item))
        {
            if (item as Coin) countCoin += item.Count;
            if (item as Mana) countMana += item.Count;
            item.Collect();
        }
            
    }

    private void OnDestroy()
    {
        Navigation.Instance.Die();
    }
    }

    public interface ICoin
    {
    }
}