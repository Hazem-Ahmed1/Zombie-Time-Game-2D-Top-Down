using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanAction : MonoBehaviour
{
    [SerializeField] private float detectionRangeX;
    public GameObject player;
    public Animator animator;
    public GameObject WomansBullet;
    public Transform FirePointOfBullet;
    public AudioSource shoot;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayerX = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayerX <= detectionRangeX)
        {
            animator.SetTrigger("attack");
        }
    }


    public void AttackTheZombie()
    {
        bool oneIsGone = false;
        if (!oneIsGone)
        {
            GameObject Bullet = Instantiate(WomansBullet, FirePointOfBullet.transform.position, FirePointOfBullet.transform.rotation);
            oneIsGone = true;
            shoot.Play();
        }
    }

    // Draw the detection range in the Unity Editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRangeX);
    }
}
