using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float health;

    private void Start()
    {
        health = 75f;
    }

    public virtual void TakeDamage(float playerDamage)
    {
        health -= playerDamage;
        Debug.Log($"Object took {playerDamage} damage. Remaining HP: {health}");
    }

    public virtual bool IsDead()
    {
        return health <= 0;
    }

    public virtual void DisableObject()
    {
        // Hier können Sie Code hinzufügen, um das Objekt zu deaktivieren oder andere Aktionen auszuführen.
        gameObject.SetActive(false);
    }
}

