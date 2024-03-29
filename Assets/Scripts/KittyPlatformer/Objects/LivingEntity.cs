﻿using System;
using KittyPlatformer.Base;
using KittyPlatformer.Enemy;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Objects 
{
    public class LivingEntity : Entity, ILiving
    {
        [SerializeField] private int maxHealthPoint;
        [SerializeField] private LootDropper dropper;

        public int MaxHealthPoint => maxHealthPoint;

        public int HealthPoint { get; private set; }

        public event Action HealthChanged;

        public void GetDamage(int value)
        {
            if (value < 0)
                throw new Exception("value should be greater than zero");
            if (HealthPoint - value < 0)
                HealthPoint = 0;
            HealthPoint -= value;
            OnHealthChanged();
        }

        public void GetHealth(int value)
        {
            if (value < 0)
                throw new Exception("value should be greater than zero");
            if (HealthPoint + value > maxHealthPoint)
                HealthPoint = maxHealthPoint;
            HealthPoint += value;
            OnHealthChanged();
        }

        public virtual void OnHealthChanged()
        {
            HealthChanged?.Invoke();
        }

        private protected override void Awake()
        {
            base.Awake();
            HealthPoint = maxHealthPoint;
            HealthChanged += CheckDeath;
        }

        private void CheckDeath()
        {
            if (HealthPoint <= 0)
            {
                HealthChanged -= CheckDeath;
                Destroy(gameObject);
                OnDead();
            }
        }

        private void OnDead()
        {
            dropper.Drop(transform.position);
        }
    }
}