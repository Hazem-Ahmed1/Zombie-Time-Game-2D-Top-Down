using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGuy : MonoBehaviour
{
    Animator animator;
    public GameObject Blood_vfx;
    public AudioSource deathSound;
    [SerializeField] GameObject coinGame;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hand"))
        {
            GameObject coin = Instantiate(coinGame,transform.position,Quaternion.identity);
            animator.SetTrigger("death");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameObject effect = Instantiate(Blood_vfx, transform.position, Quaternion.identity);
            deathSound.Play();

        }
    }




}
