using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Monitor : MonoBehaviour
{
    public GameObject[] monitors;//monitors[0]には何も淹れない
    public GameObject offMonitorsL;
    public GameObject offMonitorsR;
    public MoveNext moveNext;
    public GameObject[] beginOffMonitor;//めんどくさいので最初に描画しないモニターは手動で設定したれ
    public int canSee;//表示されるモニターの値(180)
    //リソースに画像を入れるのをやめよう
    void Start()
    {
        monitors[(moveNext.index%moveNext.allObjects)].SetActive(true);
        canSee = (90 / moveNext.moveAngle);//横90°+1で白飛び防止
        foreach(GameObject beginOff in beginOffMonitor)
        {
            beginOff.SetActive(false);
        }
        foreach (GameObject monitor in monitors)
        {
            monitor.GetComponent<VideoPlayer>().Pause();
        }
        monitors[moveNext.index % moveNext.allObjects].GetComponent<VideoPlayer>().Play();
    }
    void Update()
    {
        offMonitorsL = monitors[((moveNext.index-canSee)%moveNext.allObjects)];
        offMonitorsR = monitors[((moveNext.index+canSee)%moveNext.allObjects)];
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            monitors[((moveNext.index-canSee-1)%moveNext.allObjects)].SetActive(false);
            monitors[((moveNext.index+canSee)%moveNext.allObjects)].SetActive(true);
            foreach(GameObject monitor in monitors)
            {
                monitor.GetComponent<VideoPlayer>().Pause();
            }
            monitors[moveNext.index % moveNext.allObjects].GetComponent<VideoPlayer>().Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            monitors[((moveNext.index+canSee+1)%moveNext.allObjects)].SetActive(false);
            monitors[((moveNext.index-canSee)%moveNext.allObjects)].SetActive(true);
            foreach (GameObject monitor in monitors)
            {
                monitor.GetComponent<VideoPlayer>().Pause();
            }
            monitors[moveNext.index % moveNext.allObjects].GetComponent<VideoPlayer>().Play();
        }
    }
}
