using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}













/* NEUES KAMERA MOVEMENT SKRIPT:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0f;
    public float rotationSpeed = 40f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (player != null)
        {
            // Kamera folgt dem Player
            Vector3 targetPosition = player.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Kamera-Rotation basierend auf Mausbewegung
            HandleRotationInput();
        }
    }

    void HandleRotationInput()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // Nur rotieren, wenn die Maus horizontal bewegt wird
        if (Mathf.Abs(mouseX) > 0.1f)
        {
            Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(player.position);

            // Normalisierte Mausposition im Bereich [-1, 1] um den Player herum
            float normalizedMouseX = (Input.mousePosition.x - playerScreenPos.x) / (Screen.width * 0.5f);

            // Rotiere die Kamera um den Player
            transform.RotateAround(player.position, Vector3.up, normalizedMouseX * rotationSpeed * Time.deltaTime);
        }
    }
}


*/

