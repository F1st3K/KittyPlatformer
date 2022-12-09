using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 _pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }

    private void Update()
    {
        _pos.x = player.position.x;
        _pos.y = player.position.y +3f;
        _pos.z = -10f;
        
        transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime);
    }
    
}