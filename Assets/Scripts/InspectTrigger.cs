using UnityEngine;

public class InspectTrigger : MonoBehaviour
{
    public GameObject inspectUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inspectUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inspectUI.SetActive(false);
        }
    }
}