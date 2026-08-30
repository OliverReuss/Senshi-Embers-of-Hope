using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BiomManager : MonoBehaviour
{
    public TMP_Text biomText;

    void Start()
    {
        biomText = GameObject.Find("DeinTMPTextObjektName")?.GetComponent<TMP_Text>();

        if (biomText == null)
        {
            Debug.LogError("TMP-Textobjekt nicht gefunden!");
        }
        else
        {
            // Rufe die Funktion HideUI alle 5 Sekunden auf, beginnend nach 5 Sekunden
            InvokeRepeating("HideUI", 5f, 5f);
        }
    }

    // Funktion zum Aktualisieren des Biomtexts
    public void UpdateBiomText(string biomName)
    {
        biomText.text = "Biom: " + biomName;
    }

    // Funktion zum Ausblenden und erneuten Aktivieren der UI-Elemente
    private void HideUI()
    {
        // Hier kannst du die erforderlichen Schritte zum Ausblenden der UI-Elemente durchführen
        biomText.text = "";

        // Nach einer kurzen Verzögerung wird die Funktion UnhideUI aufgerufen
        Invoke("UnhideUI", 0.1f);
    }

    // Funktion zum erneuten Aktivieren der UI-Elemente
    private void UnhideUI()
    {
        // Hier kannst du die erforderlichen Schritte zum erneuten Aktivieren der UI-Elemente durchführen
        // Zum Beispiel: Setze den Text zurück oder aktiviere das GameObject
        UpdateBiomText("DeinStandardBiomName");
    }
}
