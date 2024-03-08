using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatBehavoiur : MonoBehaviour
{
    [SerializeField] private float detectionRange;
    public GameObject playerObject; 

    private bool isPlayerDetected = false;
    private Animator animator;

    [SerializeField] GameObject SwatBullet;
    [SerializeField] GameObject firePoint;

    [SerializeField] GameObject Blood_vfx;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource fire;
    bool isBullet = false;

    public Genrator gen;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isPlayerDetected && playerObject != null && gen.LightOff == false)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);
            if (distanceToPlayer <= detectionRange)
            {
                isPlayerDetected = true;
                animator.SetBool("attack", true);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hand"))
        {
            animator.SetTrigger("death");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameObject effect = Instantiate(Blood_vfx, transform.position, Quaternion.identity);
            deathSound.Play();
        }
    }


    public void attackSwat()
    {
        if (!isBullet)
        {

            Instantiate(SwatBullet,firePoint.transform.position,firePoint.transform.rotation);
            isBullet = true;
            fire.Play();

        }
    }

}
