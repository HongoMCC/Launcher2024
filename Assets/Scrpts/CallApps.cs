using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;
using System.CodeDom;
using System.Threading.Tasks;

public class CallApps : MonoBehaviour
{
    public MoveNext moveNext;
    public int index;
    public string exepath;
    public string readmePath;
    public string type;
    public bool isHTML;
    public bool isNeedQuit;
    public GameObject error;
    public string hantei;
    public int currentNum;
    public bool exception;//過去のアプリとの互換性を保持するために残した旧名オプション
    private void Update()
    {
        index = moveNext.index%moveNext.allObjects;
        if(isHTML){ type = "html";}
        else if(!exception){type = "exe";}
        else { type = "bat"; }//HSP製のmediaフォルダを参照するレガシーアプリはそこのバッチファイルで起動
        exepath = Path.Combine(Application.dataPath, "../Apps/GAME" + index + "/main." + type);
        readmePath = Path.Combine(Application.dataPath, "../Apps/GAME" + index + "/readme.txt");
        if (Input.GetKeyDown(KeyCode.Z)&&index == currentNum&&!exception) 
        {
            LaunchApp();
        }
        if (Input.GetKeyDown(KeyCode.Z) && index == currentNum && exception)
        {
            LaunchApp();
        }
        if(Input.GetKeyDown(KeyCode.X)&&index == currentNum)
        {
            LaunchReadMe();
        }
        if(isNeedQuit)
        {
            hantei = "true";
        }
        else
        {
            hantei = "false";
        }
    }
    public void LaunchApp()
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
                if(!isNeedQuit)
                {
                    process.Exited += OnEndGame;
                }
                process.Start();
                moveNext.isAppExited = false;
            }
            else
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo(exepath)
                };
                process.EnableRaisingEvents = true;
                if (!isNeedQuit)
                {
                    process.Exited += OnEndGame;
                }
                process.Start();
                moveNext.isAppExited = false;
            }
            if (isNeedQuit == true)
            {
                Application.Quit();
            }
        }
        catch(Exception ex)
        {
            error.SetActive(true);
            UnityEngine.Debug.Log("errorMessage1:"+ex.Message);
        }
    }

    private async void OnEndGame(object sender, EventArgs e)
    {
        await Task.Delay(3000);
        moveNext.isAppExited = true;
    }

    /*public void LaunchAppOld()//HSP製の過去作を
    {
        // バッチファイルの作成
        string curDict = Directory.GetCurrentDirectory();
        string batfilePath = Path.Combine(curDict, "Start.bat");
        string[] batfileData = new string[2];
        batfileData[0] = "@echo off"; // コマンドプロンプトに結果を表示しないだけなので、任意
        batfileData[1] = @"cd /c start Apps\GAME"+index.ToString()+@"\main.exe"; // "cmd /c"は任意
        File.WriteAllLines(batfilePath, batfileData);
        // プロセスの開始
        Process cmd = new Process();
        cmd.StartInfo.UseShellExecute = false;
        cmd.StartInfo.FileName = batfilePath;
        //cmd.StartInfo.CreateNoWindow = true; // 任意
        cmd.Start();
        // 終わるのを待ってからファイルを削除
        cmd.WaitForExit();
        // cmd.Close() // "cmd /c"が無いならおそらく必要
        File.Delete(batfilePath);
    }*/
    public void LaunchReadMe()
    {
        try
        {
            Process.Start(readmePath);
        }
        catch(Exception ex)
        {
            error.SetActive(true);
            UnityEngine.Debug.Log("errorMessage2:" + ex.Message);
        }
    }
    /*void OnEndGame(object sender, System.EventArgs e)
    {
        Process process = sender as Process;

        if (process != null)
        {
            int exitCode = process.ExitCode;
            if (exitCode == 0) { }
            else
            {
                error.SetActive(true);
            }
        }
    }*/

}
//以下一括で管理しようとしてた頃の遺物    
/*//public string appFileName;
    public MoveNext moveNext;
    public int index;
    string exepath;
    string readmePath;
    string type;
    public int[] htmlGames;
    public void Start()
    {
        index = moveNext.index;
        exepath = Path.Combine(Application.dataPath,"../Apps/Games/Game"+index+"/main."+type);
        readmePath = Path.Combine(Application.dataPath,"../Apps/Games/Game"+index+"/readme.txt");
    }
    void Update()
    {
        if(index == htmlGames[0]){type = "html";}
        else{type = "exe";}
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Process.Start(exepath);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Process.Start(readmePath);
        }
    }
}*/
