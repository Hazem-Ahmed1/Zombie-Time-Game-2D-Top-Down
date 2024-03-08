using System.Collections;
using UnityEngine;

public class TurnIntoZombie : MonoBehaviour
{
    Animator animator;
    public GameObject newZombie;
    bool isInfected = false;
    public GameObject zombieEffect;
    public AudioSource newZ;
    public AudioSource infected;
    [SerializeField] public GameObject coinGameObject;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            animator.SetTrigger("death");
            Destroy(gameObject, 1f);
            if (!isInfected)
            {
                GameObject coin = Instantiate(coinGameObject, transform.position, Quaternion.identity);
                GameObject effect = Instantiate(zombieEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1.5f);
                isInfected = true;
                StartCoroutine(NewZombieInst());
                infected.Play();

            }

        }
    }

    IEnumerator NewZombieInst()
    {
        yield return new WaitForSeconds(0.9f);
        newZ.Play();
        GameObject zombie = Instantiate(newZombie, transform.position, Quaternion.identity);
        zombie.tag = "zombie";
    }
}
