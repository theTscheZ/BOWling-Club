using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;
    [SerializeField] private float arrowMaxSpeed = 10;
    
    public void PrepareArrow()
    {
        Transform arrowTransform = midPointVisual.transform.Find("Arrow");
        arrowTransform.gameObject.SetActive(true);
    }
    
    public void ResetArrow(float strength)
    {
        Transform arrowTransform = midPointVisual.transform.Find("Arrow");
        arrowTransform.gameObject.SetActive(false);
        
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.transform.position, midPointVisual.transform.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
    }
    
}
