using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NarrationManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("CrimeScene");
    }
}