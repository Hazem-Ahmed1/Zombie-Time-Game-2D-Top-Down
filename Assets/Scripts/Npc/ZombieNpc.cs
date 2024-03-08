using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNpc : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 3f;
    private float moveDistance = 30f;

    private bool isMovingRight = true;
    private float moveCounter = 0f;

    void Update()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            moveCounter += moveSpeed * Time.deltaTime;
            if (moveCounter >= moveDistance)
            {
                FlipZombieDirection();
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            moveCounter += moveSpeed * Time.deltaTime;
            if (moveCounter >= moveDistance)
            {
                FlipZombieDirection();
            }
        }
    }

    void FlipZombieDirection()
    {
        isMovingRight = !isMovingRight;
        moveCounter = 0f;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
