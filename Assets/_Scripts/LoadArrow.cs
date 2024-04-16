using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LoadArrow : MonoBehaviour
{
    [SerializeField] GameObject midPointVisual;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<GrabbableArrowIdentifier>() != null)
        {
            Debug.Log("Arrow loaded");
            Transform arrowTransform = midPointVisual.transform.Find("Arrow");
            arrowTransform.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
