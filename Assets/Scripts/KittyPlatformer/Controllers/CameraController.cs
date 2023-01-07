using UnityEngine;

namespace KittyPlatformer.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float mullSpeed;
        [SerializeField] private float relativePositionX;
        [SerializeField] private float relativePositionY;
        [SerializeField] private float indexZ;

        private Vector3 _currentPosition;

        private void Update()
        {
            if (player)
            {
                Vector3 position = player.position;
                _currentPosition.x = position.x + relativePositionX;
                _currentPosition.y = position.y + relativePositionY;
                _currentPosition.z = indexZ;
                transform.position = Vector3.Lerp(transform.position, _currentPosition, mullSpeed * Time.deltaTime);
            }
        }
    }
}