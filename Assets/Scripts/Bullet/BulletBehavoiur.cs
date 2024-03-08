using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavoiur : MonoBehaviour
{
    public GameObject VFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(VFX,transform.position,Quaternion.identity);
        Destroy(effect,1f);
        Destroy(gameObject);
    }

}
