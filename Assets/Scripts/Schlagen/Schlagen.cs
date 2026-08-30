using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Schlagen : MonoBehaviour
{
    [SerializeField] private AudioSource punchSoundEffect;
    private float lastClickTime;
    private int clickCount;
    Animator animator;

    public float playerDamage = 25f;
    public float attackRange = 2f;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("ResetSchlag", true);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Schlag");

            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick < 0.3f)
            {
                clickCount = Mathf.Min(clickCount + 1, 3); // Doppelklick
            }
            else
            {
                clickCount = 1; // Einzelklick
            }

            lastClickTime = Time.time;

            PerformAction();
        }
    }

    void PerformAction()
    {
        // Hier kannst du den Code f�r die Aktion des Spielers einf�gen
        switch (clickCount)
        {
            case 1:
                Debug.Log("Einzelklick: Schlag ausf�hren");
                // Hier den Code f�r den Einzelschlag einf�gen
                CheckForHit("Gegner");
                CheckForHit("Baum");
                CheckForHit("Gras");
                break;
            case 2:
                Debug.Log("Doppelklick: Doppelte Kombi ausf�hren");
                // Hier den Code f�r die doppelte Kombination einf�gen
                CheckForHit("Gegner");
                CheckForHit("Baum");
                CheckForHit("Gras");
                break;
            case 3:
                Debug.Log("Dreifachklick: Dreifache Kombi ausf�hren");
                // Hier den Code f�r die dreifache Kombination einf�gen
                CheckForHit("Gegner");
                CheckForHit("Baum");
                CheckForHit("Gras");
                break;
        }
    }


    void CheckForHit(string tag)
    {
        punchSoundEffect.Play();
        // �berpr�fe, ob der Spieler ein Objekt mit dem entsprechenden Tag getroffen hat
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(tag))
            {
                // �berpr�fe, ob der Spieler in der N�he des Objekts ist
                float distance = Vector3.Distance(transform.position, hit.transform.position);

                if (distance <= attackRange)
                {
                    // Das Objekt wurde getroffen
                    Debug.Log("HIT");
                    ObjectController objectController = hit.collider.GetComponent<ObjectController>();

                    if (objectController != null)
                    {
                        // Verursache Schaden am Objekt basierend auf dessen HP
                        objectController.TakeDamage(playerDamage);

                        // �berpr�fe, ob das Objekt keine HP mehr hat
                        if (objectController.IsDead())
                        {
                            // Deaktiviere das Objekt oder f�hre andere Aktionen durch
                            objectController.DisableObject();
                        }
                    }
                }
            }
        }
    }
}
