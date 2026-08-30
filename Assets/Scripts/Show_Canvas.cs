using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Canvas : MonoBehaviour
{
    public Canvas canvas;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }
}