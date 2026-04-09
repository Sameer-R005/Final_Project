using UnityEngine;

public class JournalToggle : MonoBehaviour
{
    public GameObject journalPanel;
    public KeyCode toggleKey = KeyCode.J;

    void Start()
    {
        if (journalPanel != null)
        {
            journalPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleJournal();
        }
    }

    void ToggleJournal()
    {
        if (journalPanel != null)
        {
            journalPanel.SetActive(!journalPanel.activeSelf);
        }
    }
}