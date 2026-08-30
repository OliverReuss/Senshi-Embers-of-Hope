using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruecke : MonoBehaviour
{
    public float bewegungsgeschwindigkeit = 1.0f;
    public float maxBewegung = -5.0f;
    public float deaktivierungsZeit = 5.0f;
    public float vibrationsDauer = 1.0f;
    public float vibrationsStaerke = 0.2f;

    private Vector3 urspruenglichePosition;
    private bool bewegungNachUnten = false;

    private void Start()
    {
        urspruenglichePosition = transform.position;
    }

    private void Update()
    {
        if (bewegungNachUnten)
        {
            transform.Translate(Vector3.down * bewegungsgeschwindigkeit * Time.deltaTime);

            if (transform.position.y <= maxBewegung)
            {
                gameObject.SetActive(false);
                Invoke("AktiviereBruecke", deaktivierungsZeit);
            }
        }
    }

    private void StarteHerunterfallAnimation()
    {
        bewegungNachUnten = true;
    }

    private void AktiviereBruecke()
    {
        transform.position = urspruenglichePosition;
        gameObject.SetActive(true);
        bewegungNachUnten = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(VibrationsHerunterfallAnimation());
        }
    }

    private IEnumerator VibrationsHerunterfallAnimation()
    {
        float startTime = Time.time;

        while (Time.time - startTime < vibrationsDauer)
        {
            float xOffset = Mathf.Sin(Time.time * Mathf.PI * 2 * 10) * vibrationsStaerke;
            transform.position = urspruenglichePosition + new Vector3(xOffset, 0, 0);

            yield return null;
        }

        transform.position = urspruenglichePosition;

        StarteHerunterfallAnimation();
    }
}

