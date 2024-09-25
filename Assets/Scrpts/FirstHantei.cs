using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstHantei : MonoBehaviour
{
    public bool isScene;
    public GameObject first;
    public GameObject second;
    bool isend = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!isScene&&!File.Exists(Path.Combine(Application.dataPath,@"../savedata/firstboot.txt")))
        {
            SceneManager.LoadScene("FirstBoot");
        }
        if(isScene)
        {
            string path = Path.Combine(Application.dataPath, @"../savedata/firstboot.txt");
            File.WriteAllText(path, "‚³‚¢‚½‚Ü");
        }
    }

    private void Update()
    {
        if(isend)
        {
            first.SetActive(false);
            second.SetActive(true);
        }
    }
    public void OnclickInstall()
    {
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo(Path.Combine(Application.dataPath, @"../Apps/Installer/net8.exe"))
        };
        process.EnableRaisingEvents = true;
        process.Exited += OnExit;
        process.Start();
    }
    public void OnclickCancel()
    {
        SceneManager.LoadScene("title");
    }

    public void OnExit(object sender,EventArgs e)
    {
        UnityEngine.Debug.Log("saitama");
        isend = true;
    }
}
