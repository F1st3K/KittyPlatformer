using System;
using UnityEngine;

namespace Interfaces
{
    public class LivingEntity : Entity, ILiving
    {
        [SerializeField] private int maxHealthPoint;

        public LivingEntity()
        {
            HealthPoint = maxHealthPoint;
        }

        public int MaxHealthPoint => maxHealthPoint;

        public int HealthPoint { get; private set; }

        public void GetDamage(int value)
        {
            if (value < 0)
                throw new Exception("value should be greater than zero");
            if (HealthPoint - value < 0)
                HealthPoint = 0;
            HealthPoint -= value;
        }

        public void GetHealth(int value)
        {
            if (value < 0)
                throw new Exception("value should be greater than zero");
            if (HealthPoint + value > maxHealthPoint)
                HealthPoint = maxHealthPoint;
            HealthPoint += value;
        }
    }
}