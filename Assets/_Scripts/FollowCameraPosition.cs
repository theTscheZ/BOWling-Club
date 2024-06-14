using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraPosition : MonoBehaviour
{
    public Transform cameraTransform; // Referenz auf die Kamera
    public Transform rigTransform;    // Referenz auf das XR Rig

    void Update()
    {
        // Berechne die Position des Child relativ zum XR Rig, unter Beibehaltung der ursprünglichen Höhe
        Vector3 cameraLocalPosition = rigTransform.InverseTransformPoint(cameraTransform.position);
        Vector3 newPosition = new Vector3(cameraLocalPosition.x, transform.localPosition.y, cameraLocalPosition.z);

        // Setze die neue Position relativ zum XR Rig
        transform.localPosition = newPosition;

        // Ignoriere jegliche Rotation und setze die Rotation des Child auf die Identitätsrotation
        transform.rotation = Quaternion.identity;
    }
}