using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShot : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("zombie").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            Destroy(gameObject, 7f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
