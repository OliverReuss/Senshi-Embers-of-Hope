using System.Collections;
using UnityEngine;

public class GrasController : ObjectController
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private Animator animator;


    [Header("Gras Settings")]
    public float grasHealth = 50f;
    public float restorationDelay = 5f;

    public Itemdrop itemdrop;

    private bool isTakingDamage; // Flag, um zu überprüfen, ob der Schaden bereits angewendet wird

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;

        health = grasHealth;

        animator = GetComponent<Animator>();
        itemdrop = GetComponent<Itemdrop>();
    }

    public override void TakeDamage(float playerDamage)
    {
        base.TakeDamage(playerDamage);

        if (animator != null)
        {
            animator.SetTrigger("TakeDamageTrigger");

            if (health <= 0)
            {
                if (itemdrop != null)
                {
                    itemdrop.DropItem();
                }
            }
        }
    }


    public override void DisableObject()
    {
        base.DisableObject();

        Invoke("RestoreGras", restorationDelay);
    }

    private void RestoreGras()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;

        health = grasHealth;

        gameObject.SetActive(true);
    }
}


