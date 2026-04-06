using UnityEngine;

public class Evidence : MonoBehaviour
{
    public string clueID;

    private bool collected = false;

    // THIS FUNCTION FIXES YOUR ERROR
    public void Inspect()
    {
        if (collected) return;

        collected = true;

        Debug.Log("Evidence inspected: " + clueID);

        // Update journal
        if (JournalManager.Instance != null)
        {
            JournalManager.Instance.MarkClue(clueID);
        }
        else
        {
            Debug.LogError("JournalManager not found in scene.");
        }
    }
}