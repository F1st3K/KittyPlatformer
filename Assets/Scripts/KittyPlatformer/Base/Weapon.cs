using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class Weapon : MonoBehaviour, IWeaponer
    {
        [SerializeField] private int damage;
        
        public int Damage => damage;
        
        public void Fire(Vector2 direction, float power){}
    }
}