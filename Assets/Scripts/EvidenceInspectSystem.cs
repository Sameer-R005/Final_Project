using UnityEngine;

public class EvidenceInspectSystem : MonoBehaviour
{
    public Transform inspectPoint;

    GameObject currentObject;
    bool inspecting = false;

    Vector3 originalPosition;
    Quaternion originalRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inspecting)
                TryInspect();
            else
                StopInspect();
        }

        if (inspecting)
        {
            RotateObject();
        }
    }

    void TryInspect()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))
        {
            Evidence evidence = hit.collider.GetComponent<Evidence>();

            if (evidence != null)
            {
                currentObject = hit.collider.gameObject;

                originalPosition = currentObject.transform.position;
                originalRotation = currentObject.transform.rotation;

                currentObject.transform.position = inspectPoint.position;

                inspecting = true;

                evidence.Inspect();
            }
        }
    }

    void StopInspect()  
    {
        currentObject.transform.position = originalPosition;
        currentObject.transform.rotation = originalRotation;

        inspecting = false;
        currentObject = null;
    }

    void RotateObject()
    {
        float mouseX = Input.GetAxis("Mouse X") * 200 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 200 * Time.deltaTime;

        currentObject.transform.Rotate(Vector3.up, -mouseX, Space.World);
        currentObject.transform.Rotate(Vector3.right, mouseY, Space.World);
    }
}
