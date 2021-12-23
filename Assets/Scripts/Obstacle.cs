using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;
    
    private Vector3 startPos;
    private bool movingToStart;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {   //if we are moving towards the start position
        if(movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if(transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        else
        {   //if we are moving FROM the start position
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);
            if(transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }

}
