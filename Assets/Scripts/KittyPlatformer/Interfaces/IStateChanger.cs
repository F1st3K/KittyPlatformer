using Unity.VisualScripting;

namespace Interfaces
{
    public interface IStateChanger
    {
        public ISwitching SwitchingEntity { get; }

        public void SetSwitchingEntity(ISwitching obj);
        public void ToggleCurrentSwitchingEntity();
    }
}