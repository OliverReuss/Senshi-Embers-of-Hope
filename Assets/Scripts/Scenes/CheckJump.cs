using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckJump : MonoBehaviour
{
    public int count = 0;
    private TextMeshProUGUI text;
    public string aufgabe;
    private void Start()
    {
        GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = aufgabe;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        //&& GameObject.Find("Spieler 1 Variant").GetComponent<PlayerController>().isGrounded == true
        {
            Debug.Log("Sprung");
            count++;
        }


        if (count == 5)
        {
            GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = "Task completed";
            Debug.Log("Fertig");

            Invoke("LoadNewScene", 3);
            Debug.Log("Neue Szene laden");
        }
    }

    void LoadNewScene()
    {
        Debug.Log("Neue Szene geladen");
        SceneManager.LoadScene("Cutscene_3");
    }
}
