using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] private BowString bowStringRenderer;

    private XRGrabInteractable interactable;

    [SerializeField] private Transform midPointGrabObject, midPointVisualObject, midPointParent;

    [SerializeField] float bowStringStretchLimit = 0.69f;
    
    private Transform interactor;
    
    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }
    
    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }
    
    private void ResetBowString(SelectExitEventArgs args)
    {
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);
    }
    
    private void PrepareBowString(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject.transform;
    }
    
    private void Update()
    {
        if(interactor != null)
        {
            Vector3 midPointLocalSpace = 
                midPointParent.InverseTransformPoint(midPointGrabObject.position);
            
            // get the offset
            float midPointLocalZAbs = Math.Abs(midPointLocalSpace.z);

            HandleStringPushedBackToStart(midPointLocalSpace);

            HandleStringPulledBackToLimit(midPointLocalZAbs, midPointLocalSpace);
            
            HandlePullingString(midPointLocalZAbs, midPointLocalSpace);
            
            bowStringRenderer.CreateString(midPointVisualObject.position);
        }
    }

    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        // what happens when the string is pulled between point 0 and the limit
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            midPointVisualObject.localPosition = new Vector3(0,0, midPointLocalSpace.z);
        }
    }

    private void HandleStringPulledBackToLimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs >= bowStringStretchLimit)
        {
            midPointVisualObject.localPosition = new Vector3(0,0, -bowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if(midPointLocalSpace.z >= 0)
        {
            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
}