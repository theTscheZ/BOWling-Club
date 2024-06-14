using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSync : MonoBehaviour
{
    public Transform cameraTransform; // Referenz auf die Kamera

    void Update()
    {
        // Nur die Y-Rotation der Kamera übernehmen
        Vector3 rigRotation = transform.eulerAngles;
        rigRotation.y = cameraTransform.eulerAngles.y;
        transform.eulerAngles = rigRotation;
    }
}
