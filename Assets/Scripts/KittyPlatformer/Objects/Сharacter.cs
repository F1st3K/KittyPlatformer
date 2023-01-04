using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEditor.SceneManagement;
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

        public Weapon ReplaceWeapon(Weapon obj)
        {
            if (obj is not null)
            {
                (weapon.transform.position, obj.transform.position) =
                    (obj.transform.position, weapon.transform.position);
                weapon.Rotate(Vector2.right);
                Transform parent = obj.transform.parent;
                obj.transform.SetParent(weapon.transform.parent);
                weapon.transform.parent = parent;
                (weapon, obj) = (obj, weapon);
                weapon.SetOwner();
            }
            return obj;
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