using UnityEngine;

public class Evidence : MonoBehaviour
{
    public string clueTitle;

    [TextArea(2, 5)]
    public string clueDescription;

    private bool collected = false;

    public void Inspect()
    {
        if (collected) return;

        collected = true;

        Debug.Log("Evidence inspected: " + clueTitle);

        if (JournalManager.Instance != null)
        {
            JournalManager.Instance.AddClue(clueTitle, clueDescription);
        }
        else
        {
            Debug.LogError("JournalManager not found in scene.");
        }

        if (ClueCounterUI.Instance != null)
        {
            ClueCounterUI.Instance.AddClue();
        }
        else
        {
            Debug.LogError("ClueCounterUI not found in scene.");
        }
    }
}