namespace KittyPlatformer.Interfaces
{
    public interface IStateVariable
    {
        public bool IsActivate { get; }
        
        public void Activate();
        public void DeActivate();
    }
}