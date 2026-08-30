using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : ObjectController
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private Animator animator;

    [Header("Tree Settings")]
    public float treeHealth = 50f;
    public float restorationDelay = 5f;

    public Itemdrop itemdrop; // Verweis auf das Itemdrop-Skript

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;

        health = treeHealth;

        animator = GetComponent<Animator>();
        itemdrop = GetComponent<Itemdrop>();
    }

    public override void TakeDamage(float playerDamage)
    {
        base.TakeDamage(playerDamage);

        if (animator != null)
        {
            animator.SetTrigger("TakeDamageTrigger");
        }

        if (health <= 0)
        {
            if (itemdrop != null)
            {
                itemdrop.DropItem();
            }
        }
    }

    public override void DisableObject()
    {
        base.DisableObject();

        Invoke("RestoreTree", restorationDelay);
    }

    private void RestoreTree()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.localScale = originalScale;

        health = treeHealth;

        gameObject.SetActive(true);
    }
}



