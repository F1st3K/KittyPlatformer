using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class RunnerEnemy : Enemy
{
    [SerializeField] private Transform firstPosition;
    [SerializeField] private Transform secondPosition;
    [SerializeField] private float speed;
    
    private SpriteRenderer _sprite;

    private void Start()
    {
        firstPosition = transform;
        secondPosition.position = secondPosition.TransformPoint(0, 0, 0);
        

    }

    private void Wander()
    {
        var prevPosition = transform.position;
        var postPosition = new Vector3(secondPosition.position.x, prevPosition.y);
        var currentPosition = Vector3.MoveTowards(prevPosition,
                                                          postPosition,
                                                 speed*Time.deltaTime);
        transform.position = currentPosition;
    }
    
    private void CheckWanderPosition()
    {
        if (transform.position == secondPosition.position)
        {
            secondPosition = firstPosition;
            firstPosition.position = transform.position;
        }
    }

    private void Update()
    {
        Wander();
    }
    
    private void FixedUpdate()
    {
        CheckWanderPosition();
    }

}