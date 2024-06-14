using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLimiter : MonoBehaviour
{
    public float movementRadius = 0.3f; // Radius, in dem sich der Spieler frei bewegen kann
    private Vector3 initialPosition;

    void Start()
    {
        // Speichere die initiale Position relativ zum XR Rig
        initialPosition = transform.localPosition;
    }

    void LateUpdate()
    {
        // Berechne die aktuelle Position relativ zur initialen Position
        Vector3 offset = transform.localPosition - initialPosition;

        // Wenn die Distanz zum Ursprung größer als der erlaubte Radius ist, korrigiere die Position
        if (offset.magnitude > movementRadius)
        {
            // Normalisiere den Offset und skaliere ihn auf den erlaubten Radius
            offset = offset.normalized * movementRadius;
            // Setze die neue Position relativ zur initialen Position
            transform.localPosition = initialPosition + offset;
        }
    }
}
