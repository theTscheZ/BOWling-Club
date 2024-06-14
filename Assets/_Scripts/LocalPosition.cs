using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPosition : MonoBehaviour
{
    void Start()
    {
        // Starte die Funktion zum Loggen der Position jede Sekunde
        InvokeRepeating("LogPosition", 0f, 1f);
    }

    void LogPosition()
    {
        // Logge die lokale Position des GameObjects
        Debug.Log($"Lokale Position von '{gameObject.name}': {transform.localPosition}");

        // Logge die globale Position des GameObjects
        Debug.Log($"Globale Position von '{gameObject.name}': {transform.position}");
    }
    
    void Update()
    {
        // Bewege das GameObject um 0.1 Einheiten entlang der X-Achse
        // transform.localPosition = Vector3.zero;
    }
}
