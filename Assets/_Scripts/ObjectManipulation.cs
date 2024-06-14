using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectManipulation : MonoBehaviour
{
    public InputActionReference bButtonAction;
    public GameObject objectPrefab;
    private GameObject spawnedObject;
    public Transform leftControllerTransform; // Linker Controller Transform

    private void OnEnable()
    {
        bButtonAction.action.Enable();
        bButtonAction.action.performed += OnBButton;
        bButtonAction.action.canceled += OnBButton;
    }

    private void OnDisable()
    {
        bButtonAction.action.Disable();
        bButtonAction.action.performed -= OnBButton;
        bButtonAction.action.canceled -= OnBButton;
    }

    private void OnBButton(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>() + " B-Button gedrückt");
        if (context.ReadValue<float>() > 0)
        {
            // B-Button gedrückt
            if (spawnedObject == null)
            {
                // Spawn des GameObjects neben dem linken Controller
                spawnedObject = Instantiate(objectPrefab, leftControllerTransform.position, leftControllerTransform.rotation);
            }
        }
        else
        {
            // B-Button losgelassen
            if (spawnedObject != null && !spawnedObject.GetComponent<XRGrabInteractable>().isSelected)
            {
                Destroy(spawnedObject);
                spawnedObject = null;
            }
        }
    }

    private void Update()
    {
        // Wenn das GameObject existiert, aktualisiere seine Position und Rotation basierend auf dem linken Controller
        if (spawnedObject != null && !spawnedObject.GetComponent<XRGrabInteractable>().isSelected)
        {
            spawnedObject.transform.position = leftControllerTransform.position;
            spawnedObject.transform.rotation = leftControllerTransform.rotation;
        }
    }
}