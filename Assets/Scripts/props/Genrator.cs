using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Genrator : MonoBehaviour
{
    Animator animator;
    float hp = 100f;
    public GameObject smokeEffect;
    bool smokeEffectOnce = false;
    bool generatorDestroyed;
    public bool LightOff = false;
    public float generatorCounter;
    public AudioSource Destruction;
    [SerializeField] Light2D doorLight;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("genHp", hp);

        if (hp < 51 && hp > 0)
        {
            if (!smokeEffectOnce)
            {
                GameObject effect = Instantiate(smokeEffect, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
                smokeEffectOnce = true;

            }
        }

        if(hp < 1 && !generatorDestroyed)
        {
            LightOff = true;
            generatorCounter++;
            generatorDestroyed = true;
        }

        if (LightOff)
        {
            doorLight.intensity = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("hand"))
        {
            hp = hp - 50;
            Destruction.Play();
        }
    }


}
