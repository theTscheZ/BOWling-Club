using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLogic : MonoBehaviour
{
    private bool _scored;
    private Rigidbody _rigidbody;
    private float _velocity;

    private void Start()
    {
        _scored = false;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log(_velocity);
    //     if (!_scored && (collision.collider.CompareTag("Arrow") || collision.collider.CompareTag("Pin")))
    //     {
    //         _scored = true;
    //     }
    // }

    private void Update()
    {
        _velocity = GetComponent<Rigidbody>().velocity.magnitude;

        if (!_scored && _velocity >= 0.5f &&
            (Mathf.Abs(transform.eulerAngles.x) > 30 || Mathf.Abs(transform.eulerAngles.z) > 30))
        {
            Score.Point++;
            Debug.Log("Score: " + Score.Point);
            _scored = true;
        }
    }
}