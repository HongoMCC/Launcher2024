using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class option : MonoBehaviour
{
    public bool isOption;
    public VideoPlayer videoPlayer;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        if(!isOption)
        {
            videoPlayer = game.GetComponent<VideoPlayer>();
            videoPlayer.loopPointReached += FinishPlaying;
        }
    }
    void FinishPlaying(VideoPlayer vp)
    {
        SceneManager.LoadScene("option");
    }
    public void OnClick1()
    {
        SceneManager.LoadScene("credit");
    }
    public void OnClick2()
    {
        SceneManager.LoadScene("aboutapp");
    }
    public void OnClick3()
    {
        Process.Start(Path.Combine(Application.dataPath + "../readme.txt"));
    }
    public void OnClick4()
    {
        Process.Start(Path.Combine(Application.dataPath + "../“Á•Ê•t˜^"));
    }
    public void OnClick5()
    {
        SceneManager.LoadScene("title");
    }
    public void OnClick6()
    {
        SceneManager.LoadScene("option");
    }
    public void OnClickOptional()
    {
        SceneManager.LoadScene("option");
    }
}
