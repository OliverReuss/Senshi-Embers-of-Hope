using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baum : MonoBehaviour
{
    
    private bool rotateClockwise = true;
    public float rotationSpeed;

    void Start()
    {

    }


    void Update()
    {
        BaumAnimated();
    }

    void BaumAnimated()
    {
        if (rotateClockwise)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.World);
            if (transform.eulerAngles.z >= 5f && transform.eulerAngles.z <= 180f)
            {
                rotateClockwise = false;
            }
        }
        else
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.World);
            if (transform.eulerAngles.z <= 355f && transform.eulerAngles.z >= 180f)
            {
                rotateClockwise = true;
            }
        }
    }
    
}


