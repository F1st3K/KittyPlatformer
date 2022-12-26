using UnityEngine;

namespace Interfaces
{
    public abstract class Weapon : MonoBehaviour, IWeaponer
    {
        [SerializeField] private int damage;
        
        public int Damage => damage;

        public void Fire()
        {
            
        }
    }
}