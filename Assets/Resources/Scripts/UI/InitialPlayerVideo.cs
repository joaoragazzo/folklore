using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class InitialPlayerVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Assine o evento loopPointReached
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    // Método chamado quando o vídeo termina
    void OnVideoEnded(VideoPlayer vp)
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}