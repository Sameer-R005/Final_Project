using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public string startMenuSceneName = "StartMenu";

    public void PlayAgain()
    {
        SceneManager.LoadScene(startMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Game Quit");
    }
}