// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;
//
// public class Quiver : XRBaseInteractable
// {
//     public GameObject arrowPrefab = null;
//
//     protected override void OnEnable()
//     {
//         base.OnEnable();
//         selectEntered.AddListener(InstantiateAndGrabObject);
//     }
//
//     protected override void OnDisable()
//     {
//         base.OnDisable();
//         selectEntered.RemoveListener(InstantiateAndGrabObject);
//     }
//     
//     private void InstantiateAndGrabObject(SelectEnterEventArgs args)
//     {
//         // Instanziere das Objekt
//         GameObject instance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
//
//         // Hole das XR Grab Interactable Component des instanziierten Objekts
//         XRGrabInteractable grabInteractable = instance.GetComponent<XRGrabInteractable>();
//
//         if (grabInteractable != null)
//         {
//             // Führe das automatische Greifen des Objekts aus
//             StartCoroutine(WaitAndGrab(grabInteractable));
//         }
//     }
//
//     private System.Collections.IEnumerator WaitAndGrab(XRGrabInteractable grabInteractable)
//     {
//         yield return new WaitForEndOfFrame();
//
//         // Überprüfe, welcher Interactor gerade interagiert
//         XRBaseInteractor currentInteractor = GetCurrentInteractor();
//
//         if (currentInteractor != null)
//         {
//             // Der Interactor soll das Objekt greifen
//             currentInteractor.interactionManager.SelectEnter(currentInteractor, grabInteractable);
//         }
//     }
//     
//     private XRBaseInteractor GetCurrentInteractor()
//     {
//         // Finde alle aktiven Interactors in der Szene
//         XRBaseInteractor[] interactors = FindObjectsOfType<XRBaseInteractor>();
//
//         // Überprüfe, ob einer der Interactors mit diesem Interactable interagiert
//         foreach (XRBaseInteractor interactor in interactors)
//         {
//             if (interactor.interactablesSelected.Contains(this))
//             {
//                 return interactor;
//             }
//         }
//
//         return null;
//     }
// }


using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver : XRBaseInteractable
{
    public GameObject arrowPrefab = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(InstantiateAndGrabObject);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(InstantiateAndGrabObject);
    }
    
    private void InstantiateAndGrabObject(SelectEnterEventArgs args)
    {
        // Instanziere das Objekt
        GameObject instance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        // Hole das XR Grab Interactable Component des instanziierten Objekts
        XRGrabInteractable grabInteractable = instance.GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // Führe das automatische Greifen des Objekts aus
            StartCoroutine(WaitAndGrab(grabInteractable, args.interactorObject));
        }
    }

    private System.Collections.IEnumerator WaitAndGrab(XRGrabInteractable grabInteractable, IXRSelectInteractor interactor)
    {
        yield return new WaitForEndOfFrame();

        if (interactor != null)
        {
            // Der Interactor soll das Objekt greifen
            interactionManager.SelectEnter(interactor, grabInteractable);
        }
    }
}
