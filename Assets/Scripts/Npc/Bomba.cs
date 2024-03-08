using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bomba : MonoBehaviour
{
    public CameraShake cam;

    [SerializeField] private int detectionRange;
    [SerializeField] private float speed;
    [SerializeField] public int explosionDelay = 5;
    private float explosionRadius = 1f;

    private GameObject[] zombies; // Change the type to GameObject[]
    private Transform target;
    private bool isFollowing = false;
    private Animator animator;
    private float elapsedTime = 0f;
    private bool hasExploded = false;
    private bool FireUp = false;
    public GameObject fire;
    public AudioSource booom;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Instead of finding one zombie, find all zombies
        zombies = GameObject.FindGameObjectsWithTag("zombie");

        // Iterate through each zombie to find the closest one
        float closestDistance = float.MaxValue;
        foreach (GameObject zombie in zombies)
        {
            float distance = Vector3.Distance(transform.position, zombie.transform.position);
            if (distance <= detectionRange && distance < closestDistance)
            {
                target = zombie.transform;
                closestDistance = distance;
            }
        }

        // If a target is found, start following it
        if (target != null && !isFollowing)
        {
            isFollowing = true;
            animator.SetBool("walk", true);
        }

        if (isFollowing && !hasExploded)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= explosionDelay || Vector3.Distance(transform.position, target.position) <= explosionRadius)
            {
                Explode();
                hasExploded = true;
            }
        }
    }

    void Explode()
    {
        animator.SetTrigger("bomb");
        cam.ShakeCamera(3f, .2f);
        if (!FireUp)
        {
            booom.Play();
            GameObject fireTemp = Instantiate(fire, transform.position, Quaternion.identity);
            FireUp = true;
            Destroy(fireTemp, .6f);
        }

        Destroy(gameObject, 0.5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
