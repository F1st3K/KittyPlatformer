using KittyPlatformer.Interfaces;
using KittyPlatformer.Objects;

namespace KittyPlatformer.Base
{
    public abstract class Changer : AttackerEntity, IStateChanger
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