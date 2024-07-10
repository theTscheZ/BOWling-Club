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
