using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity1 : MonoBehaviour
{
    public bool besiegt = false;
    public Rigidbody gegner;
    public Rigidbody player;

    void Start()
    {
        gegner = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(besiegt == false)
        {
            float distance = Vector3.Distance(gegner.transform.position, player.transform.position);

            if (distance < 2 && besiegt == false)
            {
                Debug.Log("Gegenr besiegt");
                besiegt = true;
                GameObject.Find("EventController").GetComponent<ProximityController>().count += 1;
                GameObject.Find(gegner.name).GetComponent<EnemyAI>().besiegt = true;
                Destroy(GameObject.Find(gegner.name).GetComponent<EnemyAI>().gegnerGo);
            }
        } 
    }
}
