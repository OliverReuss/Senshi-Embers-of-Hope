using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomTrigger : MonoBehaviour
{
    public string biomName = "Default Biom"; // Setze den Standardbiomnamen hier

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BiomManager biomManager = FindObjectOfType<BiomManager>();
            if (biomManager != null)
            {
                biomManager.UpdateBiomText(biomName);
            }
        }
    }
}

