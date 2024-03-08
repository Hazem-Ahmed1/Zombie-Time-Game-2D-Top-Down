using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatBullet : MonoBehaviour
{
    private float speed = 15f;

    void Update()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("zombie");

        if (targetObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);
            Destroy(gameObject, 7f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
