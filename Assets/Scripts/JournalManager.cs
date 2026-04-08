using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance;

    public TMP_Text journalText;
    public GameObject investigationPrompt;

    private List<string> collectedEntries = new List<string>();
    private bool promptShown = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (investigationPrompt != null)
                investigationPrompt.SetActive(false);

            UpdateJournalText();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddClue(string clueTitle, string clueDescription)
    {
        string fullEntry = "<b>" + clueTitle + "</b>\n" + clueDescription;

        if (!collectedEntries.Contains(fullEntry))
        {
            collectedEntries.Add(fullEntry);
            UpdateJournalText();
            CheckAllEvidenceCollected();
        }
    }

    void UpdateJournalText()
    {
        if (journalText == null)
        {
            Debug.LogError("Journal text is not assigned.");
            return;
        }

        if (collectedEntries.Count == 0)
        {
            journalText.text = "Evidence Collected:\n\nNo evidence collected yet.";
            return;
        }

        journalText.text = "Evidence Collected:\n\n";

        for (int i = 0; i < collectedEntries.Count; i++)
        {
            journalText.text += collectedEntries[i] + "\n\n";
        }
    }

    void CheckAllEvidenceCollected()
    {
        if (promptShown) return;

        int totalRequiredClues = 8;

        if (collectedEntries.Count >= totalRequiredClues)
        {
            promptShown = true;

            if (investigationPrompt != null)
            {
                investigationPrompt.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}