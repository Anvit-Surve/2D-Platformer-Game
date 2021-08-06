using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float distance;
    public float distanceAbove;
    public bool movingUp;
    public Transform groundDetectionUp;
    public Transform groundDetectionDown;

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * Vector2.down);
        }
        
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionUp.position, Vector2.up, distanceAbove, 1);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDetectionDown.position, Vector2.down, distance, 1);
        if (groundInfo.collider)
        {
            movingUp = false;
        }
        if(groundInfo2.collider)
        {
            movingUp = true;
        }
    }
}
