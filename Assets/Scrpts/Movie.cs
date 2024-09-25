using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public GameObject movie;
    public VideoPlayer videoPlayer;
    public GameObject uI;
    //public string sceneName;
    public void Start()
    {
        uI.SetActive(false);
        videoPlayer = movie.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += FinishPlaying;
    }
    public void FinishPlaying(VideoPlayer vp)
    {
        vp = movie.GetComponent<VideoPlayer>();
        movie.SetActive(false);
        //SceneManager.LoadScene(sceneName);
        uI.SetActive(true);
    }
}
