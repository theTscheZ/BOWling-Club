using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerAfterShot : MonoBehaviour
{
    private bool _checkVelocity;
    public Transform rigTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        _checkVelocity = false;
        //hol das transform des rigs
        rigTransform = GameObject.Find("XR Rig").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkVelocity)
        {
            // Hole die Geschwindigkeit des GameObjects
            float velocity = GetComponent<Rigidbody>().velocity.magnitude;
            // Überprüfe, ob die Geschwindigkeit kleiner als 0.5 ist
            if (velocity < 0.5f)
            {
                // Teleportiere den Spieler an die Position des GameObjects
                rigTransform.position = transform.position;
                // Lösche das GameObject
                Destroy(gameObject);
            }
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob die Kollision mit einem anderen GameObject stattgefunden hat
        if (collision.gameObject.CompareTag("Hittable")) // Hier kannst du einen bestimmten Tag verwenden, um die Art des kollidierenden Objekts zu überprüfen
        {
            _checkVelocity = true;
        }
    }
}
