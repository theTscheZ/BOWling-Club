using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider myCollider;
    [SerializeField] GameObject stickingArrow;
    
    private void OnCollisionEnter(Collision other)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;
        
        GameObject arrow = Instantiate(stickingArrow, transform.position, transform.rotation);
        arrow.transform.forward = transform.forward;
        
        if (other.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = other.collider.attachedRigidbody.transform;
        }
        
        other.collider.GetComponent<IHittable>()?.GetHit();
        Destroy(gameObject);
    }
}
