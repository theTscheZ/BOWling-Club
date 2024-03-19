using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandsAnimator : MonoBehaviour
{
    public Animator animator;
    public InputActionProperty gripAction;
    public InputActionProperty triggerAction;
    
    void Update()
    {
        var gripValue = gripAction.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);
        
        var triggerValue = triggerAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", triggerValue);
    }
}
