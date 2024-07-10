using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob die Kollision mit einem anderen GameObject stattgefunden hat
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Score.Point = 0;
            if (SceneManager.GetActiveScene().name.Equals("Level1Scenery"))
            {
                SceneManager.LoadScene("Level2Scenery");                
            }else if (SceneManager.GetActiveScene().name.Equals("Level2Scenery"))
            {
                SceneManager.LoadScene("Level1Scenery");
            }
        }
    }
}
