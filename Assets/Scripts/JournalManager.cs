using UnityEngine;
using TMPro;

public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance;

    public TMP_Text journalText;

    private bool bloodyKnifeFound = false;
    private bool bloodStainFound = false;
    private bool hammerFound = false;
    private bool victimBodyFound = false;
    private bool brokenGlassFound = false;
    private bool bookFound = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UpdateJournalText();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkClue(string clueID)
    {
        Debug.Log("Trying to mark clue: " + clueID);

        switch (clueID)
        {
            case "BloodyKnife":
                bloodyKnifeFound = true;
                break;

            case "BloodStain":
                bloodStainFound = true;
                break;

            case "Hammer":
                hammerFound = true;
                break;

            case "VictimBody":
                victimBodyFound = true;
                break;

            case "BrokenGlass":
                brokenGlassFound = true;
                break;

            case "Book":
                bookFound = true;
                break;

            default:
                Debug.LogWarning("Unknown clue ID: " + clueID);
                return;
        }

        UpdateJournalText();
    }

    void UpdateJournalText()
    {
        if (journalText == null)
        {
            Debug.LogError("Journal text is not assigned.");
            return;
        }

        journalText.text =
            (bloodyKnifeFound ? "[X] " : "[ ] ") + "Bloody Knife\n" +
            (bloodStainFound ? "[X] " : "[ ] ") + "Blood Stain\n" +
            (hammerFound ? "[X] " : "[ ] ") + "Hammer\n" +
            (victimBodyFound ? "[X] " : "[ ] ") + "Victim Body\n" +
            (brokenGlassFound ? "[X] " : "[ ] ") + "Broken Glass\n" +
            (bookFound ? "[X] " : "[ ] ") + "Book";
    }
}