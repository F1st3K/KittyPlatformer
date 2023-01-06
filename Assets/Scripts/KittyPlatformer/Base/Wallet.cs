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

        public void AddResources(int value)
        {
            if (value < 0 ||
                value > maxResources)
                throw new ArgumentException();
            countResources += value;
        }

        public void SpendResources(int value)
        {
            if (value < 0 ||
                value > countResources)
                throw new ArgumentException();
            countResources -= value;
        }

        private protected virtual void Awake()
        {
            maxResources = countResources;
        }
    }
}