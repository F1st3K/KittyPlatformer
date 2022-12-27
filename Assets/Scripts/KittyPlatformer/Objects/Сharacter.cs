using Interfaces;
using UnityEngine;
using Base;

namespace Objects
{
    public sealed class Сharacter : LivingEntity, IAttacking, IStateChanger
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        public ISwitching SwitchingEntity { get; private set; }
        
        public void Attack(Vector2 direction, float power)
        {
            weapon.Fire(direction, power);
        }

        public void SetSwitchingEntity(ISwitching obj)
        {
            SwitchingEntity = obj;
        }

        public void ToggleCurrentSwitchingEntity()
        {
            if (SwitchingEntity.IsActivate)
                SwitchingEntity.DeActivate();
            else SwitchingEntity.Activate();
        }
    }
}