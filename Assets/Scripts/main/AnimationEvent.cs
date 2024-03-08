using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    public void DoAttackUp()
    {
        transform.Find("UpAttack").GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(HideAttackUp());
    }

    IEnumerator HideAttackUp()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("UpAttack").GetComponent<CircleCollider2D>().enabled = false;
    }
    //

    public void DoAttackDown()
    {
        transform.Find("DownAttack").GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(HideAttackDown());
    }

    IEnumerator HideAttackDown()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("DownAttack").GetComponent<CircleCollider2D>().enabled = false;
    }
    //
    public void DoAttackRight()
    {
        transform.Find("RightAttack").GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(HideAttackRight());
    }

    IEnumerator HideAttackRight()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("RightAttack").GetComponent<CircleCollider2D>().enabled = false;
    }
    //
    public void DoAttackLeft()
    {
        transform.Find("LeftAttack").GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(HideAttackLeft());
    }

    IEnumerator HideAttackLeft()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("LeftAttack").GetComponent<CircleCollider2D>().enabled = false;
    }


}
