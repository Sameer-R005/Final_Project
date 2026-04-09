using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestigationPromptUI : MonoBehaviour
{
    public string firstInvestigationSceneName = "Invi1";
    public GameObject promptPanel;

    public void YesMoveToInvestigation()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(firstInvestigationSceneName);
    }

    public void StayLonger()
    {
        if (promptPanel != null)
            promptPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}