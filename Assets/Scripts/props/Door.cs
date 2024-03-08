using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    float hp = 100f;
    public GameObject smokeEffect;
    bool smokeEffectOnce = false;
    public AudioSource DestructionDoor;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("doorHealth", hp);

        if(hp < 51 && hp > 0)
        {
            if(!smokeEffectOnce)
            {
                GameObject effect = Instantiate(smokeEffect, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
                smokeEffectOnce = true;
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("hand"))
        {
            hp = hp - 50;
            DestructionDoor.Play();
        }


    }
}
