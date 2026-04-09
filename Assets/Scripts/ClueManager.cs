using UnityEngine;
using TMPro;

public class ClueCounterUI : MonoBehaviour
{
    public static ClueCounterUI Instance;

    public TextMeshProUGUI objectivesText;
    public int totalClues = 9;

    private int collectedClues = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UpdateObjectiveText();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddClue()
    {
        collectedClues++;
        UpdateObjectiveText();
    }

    private void UpdateObjectiveText()
    {
        if (objectivesText != null)
        {
            objectivesText.text = "Clues Found: " + collectedClues + "/" + totalClues;
        }
        else
        {
            Debug.LogError("Objectives Text is not assigned in ClueCounterUI.");
        }
    }
}