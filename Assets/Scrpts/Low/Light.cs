using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class LightControll : MonoBehaviour
{
    public GameObject[] position;
    public GameObject lightObject;
    public int num;
    Vector3 vector3;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public string exepath;
    public string readmePath;
    public string type;
    public bool[] htmlCheck;
    public bool[] isOldCheck;
    public bool[] isNeedQuit;
    public string[] gameNumber;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        QualitySettings.SetQualityLevel(Array.IndexOf(QualitySettings.names, "low"), true);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            num--;
            if(num < 0) { num = 14;}
            vector3 = position[num].transform.position;
            lightObject.transform.position = vector3;
            audioSource.clip = clips[0];
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            num++;
            if(num > 14)
            {
                num = 0;
            }
            audioSource.clip = clips[0];
            audioSource.Play();
            vector3 = position[num].transform.position;
            lightObject.transform.position = vector3;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CallApp(num, true);
            audioSource.clip = clips[1];
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            CallApp(num, false);
            audioSource.clip = clips[1];
            audioSource.Play();
        }
    }
    public void CallApp(int num,bool isApp)
    {
        if (htmlCheck[num])
        {
            type = "html";
        }
        else if (isOldCheck[num])
        {
            type = "bat";
        }
        else
        {
            type = "exe";
        }
        exepath = Path.Combine(Application.dataPath, "../Apps/GAME" + gameNumber[num] + "/main." + type);
        readmePath = Path.Combine(Application.dataPath, "../Apps/GAME" + gameNumber[num] + "/readme.txt");
        string hantei;
        if (isNeedQuit[num]) { hantei = "true"; }
        else { hantei = "false"; }
        if(isApp)
        {
            LaunchApp(exepath, hantei, htmlCheck[num], isNeedQuit[num]);
        }
        else
        {
            LaunchReadMe(readmePath);
        }
    }
    public void LaunchApp(string exepath,string hantei,bool isHTML,bool isNeedQuit)
    {
        try
        {
            if (isHTML)
            {
                string path = Path.Combine(Application.dataPath, "../Apps/HTML/WebSample.exe");
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = $"{exepath} {hantei}" // 引数
                };
                // 初期化
                Process process = new Process();
                process.StartInfo = processStartInfo;
                process.EnableRaisingEvents = true;
                // プロセス終了時のイベントハンドラを設定
                //process.Exited += new System.EventHandler(OnEndGame);
                process.Start();
            }
            else
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo(exepath)
                };
                process.EnableRaisingEvents = true;
                //process.Exited += new System.EventHandler(OnEndGame);
                process.Start();
            }
            if (isNeedQuit == true)
            {
                Application.Quit();
            }
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("errorMessage1:" + ex.Message);
        }
    }
    public void LaunchReadMe(string readmePath)
    {
        try
        {
            Process.Start(readmePath);
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("errorMessage2:" + ex.Message);
        }
    }
}
