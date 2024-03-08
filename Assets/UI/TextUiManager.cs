using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUiManager : MonoBehaviour
{
    public TextMeshProUGUI ammoNum;
    public PlayerFire ammo;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ammoNum.text = ammo.currentAmmo.ToString();
    }
}
