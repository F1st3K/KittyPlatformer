namespace KittyPlatformer.Interfaces
{
    public interface IStateChanger
    {
        public IStateVariable StateVariableEntity { get; }

        public void SetSwitchingEntity(IStateVariable obj);
        public void ToggleCurrentSwitchingEntity();
    }
}