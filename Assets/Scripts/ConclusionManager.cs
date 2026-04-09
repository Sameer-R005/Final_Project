using UnityEngine;
using UnityEngine.SceneManagement;

public class ConclusionManager : MonoBehaviour
{
    [Header("Correct Suspect (1, 2, or 3)")]
    public int correctSuspectID = 1;

    [Header("Scene Names")]
    public string winSceneName = "Win";
    public string gameOverSceneName = "GameOver";

    private bool hasChosen = false;

    void Update()
    {
        if (hasChosen) return;

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChooseSuspect(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChooseSuspect(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChooseSuspect(3);
        }
    }

    void ChooseSuspect(int chosenID)
    {
        hasChosen = true;

        if (chosenID == correctSuspectID)
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}