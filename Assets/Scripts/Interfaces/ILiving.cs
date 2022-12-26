using System;

namespace Interfaces
{
    public interface ILiving
    {
        public int HealthPoint { get; }
        public int MaxHealthPoint { get; }
        public event Action HealthChanged; 

        public void GetDamage(int value);
        public void GetHealth(int value);
        public void OnHealthChanged();
    }
}