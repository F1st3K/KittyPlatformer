using KittyPlatformer.Interfaces;
using UnityEngine;

namespace KittyPlatformer.Base
{
    public abstract class Item : MonoBehaviour, IItem
    {
        [SerializeField] private int count;
        
        public int Count => count;
        
        public virtual void Collect()
        {
            Destroy(gameObject);
        }
    }
}