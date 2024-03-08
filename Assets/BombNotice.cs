using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNotice : MonoBehaviour
{
    private bool gotNotice = false;
    public GameObject notice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zombie") && !gotNotice)
        {
            gotNotice = true;
            notice.SetActive(true);
            StartCoroutine(HideNotice());
        }
    }

    IEnumerator HideNotice()
    {

        yield return new WaitForSeconds(5f);
        notice.SetActive(false);

    }

}
