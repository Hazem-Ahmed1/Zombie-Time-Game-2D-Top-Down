using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public PlayerFire ammo;
    public PlayerHealth De;
    [SerializeField] public GameObject deathPanel;
    [SerializeField] public TextMeshProUGUI deathMessage;
    public AudioSource collectableThing;
    public GameObject Note;


    public string deathprompt = "YOU ARE A ZOMBIE !! " +
        "WHY TAKE CURE ?";

    public string deathprompt2 = "YOU MUST DODGE THE BULLETS";
    public string deathprompt3 = "YOU SHOULD TURN OFF THE LIGHT OF THE ROOM";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ammo")
        {
            Destroy(collision.gameObject);
            ammo.currentAmmo++;
            collectableThing.Play();
        }

        if (collision.gameObject.tag == "key")
        {
            Destroy(collision.gameObject);
            collectableThing.Play();
            Note.SetActive(true);
            StartCoroutine(HideNote());
        }

        if (collision.gameObject.tag == "cure")
        {
            Destroy(collision.gameObject);
            De.ZombieDeath();
            Invoke("afterDeathWithCure", 1.5f);
            collectableThing.Play();

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bomb")){
            De.TakeDamage(50);
        }

        if (collision.gameObject.CompareTag("oneshot"))
        {
            De.ZombieDeath();
            Invoke("afterDeathWithOneShot", 1.5f);
        }

        if (collision.gameObject.CompareTag("swatBullet"))
        {
            De.ZombieDeath();
            Invoke("afterDeathWithSwatBullet", 1.5f);
        }
    }

    private void afterDeathWithCure()
    {
        afterDeath(deathprompt);
    }

    private void afterDeathWithOneShot()
    {
        afterDeath(deathprompt2);
    }

    private void afterDeathWithSwatBullet()
    {
        afterDeath(deathprompt3);
    }


    IEnumerator HideNote()
    {

        yield return new WaitForSeconds(5f);
        Note.SetActive(false);

    }





    public void afterDeath(string prompt)
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
        deathMessage.text = prompt;
    }
}
