using System.Collections.Generic;

using System.Collections;
using UnityEngine;

public class Schatztruhe : MonoBehaviour
{
    private Animator truhenAnimator;

    public GameObject dropItem;
    [Range(0f, 1f)]
    public float dropProbability = 0.5f;

    private Vector3 originalPosition;

    private void Start()
    {
        truhenAnimator = GetComponent<Animator>();
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            truhenAnimator.SetTrigger("TruheGeoeffnet");
            StartCoroutine(StartDropTimer());
        }
    }

    private IEnumerator StartDropTimer()
    {
        yield return new WaitForSeconds(2.3f);
        DropItem();
    }

    private void DropItem()
    {
        if (Random.value <= dropProbability && dropItem != null)
        {
            Vector3 adjustedPosition = originalPosition;
            adjustedPosition.y += 1f;
            Instantiate(dropItem, adjustedPosition, Quaternion.identity);
        }
    }

    private IEnumerator ResetItem()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);
        transform.position = originalPosition;
    }
}
