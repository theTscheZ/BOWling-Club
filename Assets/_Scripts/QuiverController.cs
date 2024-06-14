using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiverController : MonoBehaviour
{
    // public Transform xrRig; // Das Transform des XR Rigs
    public Transform cameraTransform; // Das Transform der Kamera
    public Vector3 offset = new Vector3(0f, 0, 0); // Der Offset relativ zum XR Rig

    void Update()
    {
        // Berechne die neue Position des Köchers
        // Vector3 newPosition = xrRig.position + xrRig.TransformVector(offset);
        Vector3 newPosition = cameraTransform.position + cameraTransform.TransformVector(offset);

        // Setze die Position des Köchers
        transform.position = newPosition;

        // Optional: Setze die Rotation des Köchers so, dass er immer vertikal ausgerichtet bleibt
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }
}
