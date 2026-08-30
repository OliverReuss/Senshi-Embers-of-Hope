using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("Lebensanzeige").GetComponent<TextMeshProUGUI>().text = "Health: " + GameObject.Find("Spieler 2").GetComponent<PlayerController2>().playerHealth.ToString();
    }
}
