using System;
using Base;
using Interfaces;
using UnityEngine;

namespace Objects
{
    public class LivingEntity : Entity, ILiving
    {
        [SerializeField] private int maxHealthPoint;

        public LivingEntity()
        {
            HealthPoint = maxHealthPoint;
            HealthChanged += CheckDeath;
        }

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

        private void CheckDeath()
        {
            if (HealthPoint <= 0)
            {
                HealthChanged -= CheckDeath;
                Destroy(gameObject);
            }
        }
    }
}