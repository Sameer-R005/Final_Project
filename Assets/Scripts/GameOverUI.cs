using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public string retrySceneName = "Conclusion";
    public string mainMenuSceneName = "StartMenu";

    public void Retry()
    {
        SceneManager.LoadScene(retrySceneName);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}