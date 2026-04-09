using UnityEngine;

public class InspectTrigger : MonoBehaviour
{
    public GameObject inspectUI;

    private bool playerInside = false;
    private Evidence evidence;

    private void Start()
    {
        evidence = GetComponent<Evidence>();
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (evidence != null)
            {
                evidence.Inspect();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (inspectUI != null)
                inspectUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (inspectUI != null)
                inspectUI.SetActive(false);
        }
    }
}