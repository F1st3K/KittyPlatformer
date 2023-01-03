using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public sealed class Сharacter : LivingEntity, IAttacker, IStateChanger
    {
        [SerializeField] private Weapon weapon;
        
        public IWeaponer Weapon => weapon;
        public IStateVariable StateVariableEntity { get; private set; }
        
        public void Attack(float power)
        {
            weapon.Fire(power);
        }
        
        public void TakeAim(Vector2 direction)
        {
            weapon.Rotate(direction);
        }

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

        private void OnDestroy()
        {
            Navigation.Instance.Die();
        }
    }
}