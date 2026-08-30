using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public bool besucht = false;

    void OnTriggerEnter(Collider other)
    {
        if(besucht == false)
        {
            Debug.Log("Betreten");
            besucht = true;
            GameObject.Find("TriggerBoxController").GetComponent<TriggerBoxController>().count += 1;
        }
    }
}