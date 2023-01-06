using System;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class Wallet : MonoBehaviour, IWallet
    {
        [SerializeField] private int countResources;
        private protected int maxResources;

        public int CountResources => countResources;
        
        public int MaxResources => maxResources;
        
        public event Action CountChanged;

        public void AddResources(int value)
        {
            if (value < 0 ||
                value > maxResources)
                throw new ArgumentException();
            countResources += value;
            OnCountChanged();
        }

        public void SpendResources(int value)
        {
            if (value < 0 ||
                value > countResources)
                throw new ArgumentException();
            countResources -= value;
            OnCountChanged();
        }

        private void OnCountChanged()
        {
            CountChanged?.Invoke();
        }
        
        private protected virtual void Awake()
        {
            maxResources = countResources;
        }
    }
}