using UnityEngine;

public class EvidenceInspectSystem : MonoBehaviour
{
    [Header("Inspect Settings")]
    public Transform inspectPoint;
    public float inspectDistance = 5f;
    public float rotationSpeed = 200f;

    [Header("Player References")]
    public SimplePlayerController playerController;
    public CharacterController characterController;
    public MonoBehaviour simplePlayerUse;
    public MonoBehaviour footstepController;

    private GameObject currentObject;
    private bool inspecting = false;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inspecting)
                TryInspect();
            else
                StopInspect();
        }

        if (inspecting && currentObject != null)
        {
            RotateObject();
        }
    }

    void TryInspect()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, inspectDistance))
        {
            Evidence evidence = hit.collider.GetComponent<Evidence>();

            if (evidence != null)
            {
                currentObject = hit.collider.gameObject;

                originalPosition = currentObject.transform.position;
                originalRotation = currentObject.transform.rotation;

                Rigidbody rb = currentObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.isKinematic = true;
                }

                currentObject.transform.position = inspectPoint.position;
                currentObject.transform.rotation = Quaternion.identity;

                inspecting = true;

                if (playerController != null)
                    playerController.enabled = false;

                if (characterController != null)
                    characterController.enabled = false;

                if (simplePlayerUse != null)
                    simplePlayerUse.enabled = false;

                if (footstepController != null)
                    footstepController.enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                evidence.Inspect();
            }
        }
    }

    void StopInspect()
    {
        if (currentObject != null)
        {
            currentObject.transform.position = originalPosition;
            currentObject.transform.rotation = originalRotation;

            Rigidbody rb = currentObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

        inspecting = false;
        currentObject = null;

        if (playerController != null)
            playerController.enabled = true;

        if (characterController != null)
            characterController.enabled = true;

        if (simplePlayerUse != null)
            simplePlayerUse.enabled = true;

        if (footstepController != null)
            footstepController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void RotateObject()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        currentObject.transform.Rotate(Vector3.up, -mouseX, Space.World);
        currentObject.transform.Rotate(Vector3.right, mouseY, Space.World);
    }
}