using System;
using System.Drawing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float relativePositionX;
    [SerializeField] private float relativePositionY;
    [SerializeField] private float indexZ;
    
    private Vector3 _pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }

    private void Update()
    {
        var currentPosition = player.position;
        _pos.x = currentPosition.x + relativePositionX;
        _pos.y = currentPosition.y + relativePositionY;
        _pos.z = indexZ;
        
        transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime);
    }
    
}