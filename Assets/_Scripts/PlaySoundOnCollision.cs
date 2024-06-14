using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob die Kollision mit einem anderen GameObject stattgefunden hat
        if (collision.gameObject.CompareTag("Hittable") || collision.gameObject.CompareTag("Pin")) // Hier kannst du einen bestimmten Tag verwenden, um die Art des kollidierenden Objekts zu überprüfen
        {
            // Spiele den Sound ab
            GetComponent<AudioSource>().Play();
        }
    }
}
