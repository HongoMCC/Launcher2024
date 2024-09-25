using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LowMoveNext : MonoBehaviour
{
    public float speed;
    public int allObjects; // Objectの数
    public int index;
    public VideoClip[] clips; // 配列型のビデオクリップ
    private VideoPlayer player;
    private bool isVideoQueued;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
        index = 1025;

        // 動画が終了したときのイベントを登録
        player.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            PlayVideo();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index == 0)
            {
                SceneManager.LoadScene("HideScene");
            }
            else
            {
                index--;
                PlayVideo();
            }
        }
    }

    void PlayVideo()
    {
        if (player.isPlaying)
        {
            // 動画が再生中の場合は次の動画をキューに入れる
            isVideoQueued = true;
        }
        else
        {
            // 動画を再生
            player.clip = clips[index%4];
            player.Play();
            isVideoQueued = false;
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // 動画が終了し、次の動画がキューに入っている場合は再生
        if (isVideoQueued)
        {
            player.clip = clips[index%4];
            player.Play();
            isVideoQueued = false;
        }
    }
}
