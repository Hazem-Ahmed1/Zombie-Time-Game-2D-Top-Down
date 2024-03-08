using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject bloodScreen;
    public CameraShake camS;
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] public GameObject blood;
    public bool isBloody = false;
    public HealthBar hp;
    bool isDead = false;
    public Collectables deathNormal;
    public AudioSource killed;
    [SerializeField] GameObject DeathPanel;
    [SerializeField] TextMeshProUGUI deathText;
    private string Deathmessage = "YOU DIED run utill the bomb explodes";
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        hp.setMaxHealth(maxHealth);
    }



    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0 && !isDead)
        {
            ZombieDeath();
            isDead = true;
            Invoke("afterDeathNormal", 1.5f);

        }

    }



    public void ZombieDeath()
    {
        animator.SetTrigger("death");
        if (!isBloody)
        {
            GameObject effect = Instantiate(blood, transform.position, Quaternion.identity);
            isBloody = true;
        }
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        killed.Play();

    }




    public void TakeDamage(int damage)
    {
        camS.ShakeCamera(2f, 0.1f);
        currentHealth -= damage;
        hp.setHealth(currentHealth);
        StartCoroutine(ShowBlood());
    }

    public void afterDeath(string prompt)
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0;
        deathText.text = prompt;
    }
    private void afterDeathNormal()
    {
        afterDeath(Deathmessage);
    }
    IEnumerator ShowBlood()
    {
        bloodScreen.SetActive(true);
        yield return new WaitForSeconds(.4f);
        bloodScreen.SetActive(false);
    }
}
