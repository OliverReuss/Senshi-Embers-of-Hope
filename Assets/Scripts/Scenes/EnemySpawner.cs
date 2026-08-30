using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;

    public GameObject enemy1;
    public Vector3 position1;

    public GameObject enemy2;
    public Vector3 position2;

    public GameObject enemy3;
    public Vector3 position3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); ;
    }

    private void Update()
    {
        checkRespawn();
    }

    void checkRespawn()
    {
        float distance = Vector3.Distance(enemy1.transform.position, player.GetComponent<Rigidbody>().transform.position);

        //Debug.Log("Distanz: " + distance);

        if (enemy1.activeSelf == false && enemy2.activeSelf == false && enemy3.activeSelf == false && distance >= 40)
        {
            enemy1.transform.position = position1;
            enemy1.SetActive(true);

            enemy2.transform.position = position2;
            enemy2.SetActive(true);

            enemy3.transform.position = position3;
            enemy3.SetActive(true);
        }
    }
}
