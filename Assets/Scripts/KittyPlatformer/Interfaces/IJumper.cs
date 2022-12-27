namespace Interfaces
{
    public interface IJumper
    {
        public float JumpForce { get; }
    
        public void Jump(float mullForce);
        public bool CheckStayGround(float distance);
    }
}