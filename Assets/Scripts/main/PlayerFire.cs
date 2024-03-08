using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public CameraShake cam;
    public Transform firePoint;
    public GameObject bullet;
    float bulletForce = 20f;
    public float currentAmmo;
    [SerializeField] float CameraIntensity = 2.0f;
    [SerializeField] float timer = 0.1f;
    [HideInInspector] private float startAmmo = 1f;
    public AudioSource LaserShoot;


    private void Start()
    {
        currentAmmo = startAmmo;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && currentAmmo > 0)
        {
            Shoot();
            cam.ShakeCamera(CameraIntensity, timer);
        }
    }

    public void Shoot()
    {
        LaserShoot.Play();
        GameObject bulletVar = Instantiate(bullet,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bulletVar.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        currentAmmo--;
    }



}
