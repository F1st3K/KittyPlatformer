namespace Interfaces
{
    public interface ILiving
    {
        public int HealthPoint { get; }
        public bool IsAlive => HealthPoint > 0;

        public void GetDamage(int value);
        public void GetHealth(int value);
    }
}