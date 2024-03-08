using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectCoins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject winPanel;
    [HideInInspector] public int s = 16;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            s--;
        }
    }

    private void Update()
    {
        scoreText.text = s.ToString();

        if(s==0)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
