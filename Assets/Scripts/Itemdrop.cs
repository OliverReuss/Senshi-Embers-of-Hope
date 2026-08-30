using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdrop : MonoBehaviour
{
    public GameObject dropItem;
    [Range(0f, 1f)]
    public float dropProbability = 0.5f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    // Ändere den Zugriffsmodifizierer auf public oder protected
    public void DropItem()
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


