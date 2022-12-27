namespace Interfaces
{
    public interface ISwitching
    {
        public bool IsActivate { get; }
        
        public void Activate();
        public void DeActivate();
    }
}