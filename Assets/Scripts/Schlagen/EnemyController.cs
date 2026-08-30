using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyController : ObjectController
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;

    [Header("Enemy Settings")]
    public float enemyHealth = 100f;
    public float restorationDelay = 5f;

    private void Start()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;

        health = enemyHealth;
    }

    public override void TakeDamage(float playerDamage)
    {
        base.TakeDamage(playerDamage);
    }

    public override void DisableObject()
    {
        base.DisableObject();

        Invoke("RestoreEnemy", restorationDelay);
        Debug.Log("Gegner deaktivert");
    }

    private void RestoreEnemy()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;

        health = enemyHealth;

        gameObject.SetActive(true);
    }
}


