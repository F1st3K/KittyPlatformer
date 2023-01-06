using System;
using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;
using KittyPlatformer.Wallets;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class Interactor : AttackerEntity, IStateChanger, ICoinCollector, IManaCollerctor

    {
        [SerializeField] private CoinWallet coinWallet;

        public int CountCoin => coinWallet.CountResources;
        public int CountMana => manaWallet.CountResources;

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
                if (item.Count >= 0)
                {
                    if (item as Coin) coinWallet.AddResources(item.Count);
                    else if (item as Mana) manaWallet.AddResources(item.Count);
                }
                item.Collect();
            }
                
        }

        private void OnDestroy()
        {
            Navigation.Instance.Die();
        }
    }
}