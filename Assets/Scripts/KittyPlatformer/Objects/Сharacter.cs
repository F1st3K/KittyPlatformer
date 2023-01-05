using KittyPlatformer.Base;
using KittyPlatformer.Interfaces;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public sealed class Сharacter : AttackerEntity, IStateChanger
    {
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
        private void OnDestroy()
        {
            Navigation.Instance.Die();
        }
    }
}