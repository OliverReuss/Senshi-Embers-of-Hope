using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Klettern : MonoBehaviour
{

    bool clamp;
    public float clampSpeed;
    public Rigidbody rb;
    public CharacterController ch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clamp)
        {
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                transform.position += new Vector3(0, clampSpeed * Time.deltaTime, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("klettern"))
        {
            clamp = true;
            rb.useGravity = false;
            ch.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("klettern"))
        {
            clamp = false;
            rb.useGravity = true;
            ch.enabled = true;
        }
    }
}
