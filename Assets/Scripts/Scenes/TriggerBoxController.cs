using System.Collections;
using System.Collections.Generic;
using TMPro;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBoxController : MonoBehaviour
{
    public int count = 0;
    private TextMeshProUGUI text;
    public string aufgabe;
    public GameObject punkt1;
    public GameObject punkt2;
    public GameObject punkt3;
    public GameObject punkt4;
    public GameObject punkt5;

    private void Start()
    {
        GameObject.Find("Aufgabe").GetComponent<TextMeshProUGUI>().text = aufgabe;
    }

    private void Update()
    {
        if(count == 5)
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
        SceneManager.LoadScene("Cutscene_2");
    }
}
