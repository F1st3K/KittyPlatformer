using System;
using KittyPlatformer.Base;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace KittyPlatformer.Controllers
{
    public class GroundController : MonoBehaviour
    {
        private Collider2D _colider2D;
        
        public bool IsGround { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity character))
                return;
            if (other.isTrigger)
                return;
            IsGround = true;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity character))
                return;
            if (other.isTrigger)
                return;
            IsGround = false;
        }

        private void Awake()
        {
            _colider2D = GetComponent<Collider2D>();
        }
    }
}