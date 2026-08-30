using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximityController : MonoBehaviour
{
    private TextMeshProUGUI text;
    public int count;
    public string aufgabe;
    public GameObject gegner1;
    public GameObject gegner2;
    public GameObject gegner3;

    private void Start()
    {
        GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = aufgabe;
    }

    void Update()
    {
        if (gegner1.activeSelf == false && gegner2.activeSelf == false && gegner3.activeSelf == false)
        {
            GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = "Task completed";

            Invoke("LoadNewScene", 3);
        }
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("Cutscene_4");
    }
}
