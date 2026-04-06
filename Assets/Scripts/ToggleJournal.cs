using UnityEngine;

public class ToggleJournal : MonoBehaviour
{
    public GameObject journal;
    private bool isOpen = false;

    void Start()
    {
        if (journal != null)
            journal.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isOpen = !isOpen;
            journal.SetActive(isOpen);

            Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isOpen;
            Time.timeScale = isOpen ? 0f : 1f;
        }
    }
}