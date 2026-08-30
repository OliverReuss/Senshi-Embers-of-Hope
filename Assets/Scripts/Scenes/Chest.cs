using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    //private bool isOpen = false;
    private TextMeshProUGUI text;
    public string aufgabe;
    public Rigidbody player;

    private void Start()
    {
        GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = aufgabe;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfen, ob der berührende Collider vom Player ist
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = "Task completed";
            Debug.Log("Fertig");

            Invoke("LoadNewScene", 5);
            Debug.Log("Neue Szene laden");
        }
    }

    /*
    void OnTriggerStay (Collider other)
    {
        if (isOpen == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isOpen = true;
                GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = "Aufgabe erfüllt";
                Debug.Log("Fertig");

                Invoke("LoadNewScene", 3);
                Debug.Log("Neue Szene laden");

            }
        }
    }
    */

    void LoadNewScene()
    {
        Debug.Log("Neue Szene geladen");
        SceneManager.LoadScene("MainScene");
    }
}
