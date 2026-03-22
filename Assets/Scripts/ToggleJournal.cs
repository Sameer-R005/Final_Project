using UnityEngine;

public class ToggleJournal : MonoBehaviour
{
    public GameObject journal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            journal.SetActive(!journal.activeSelf);
        }
    }
}
