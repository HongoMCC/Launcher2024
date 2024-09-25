using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using UnityEngine.SceneManagement;

public class CheckStart : MonoBehaviour
{
    public void CheckInfo()
    {
        if(SystemInfo.graphicsMemorySize<4096)
        {
            SceneManager.LoadScene("low");
        }
        else
        {
            SceneManager.LoadScene("honban");
        }
    }
    private void Start()//Debug
    {
        int gpuMemorySize = SystemInfo.graphicsMemorySize;
        // GPUの名前とメモリ容量をログに出力
        Debug.Log("GPU Name: " + SystemInfo.graphicsDeviceName);
        Debug.Log("GPU Memory Size: " + gpuMemorySize + " MB");
        MessageBox.Show
            (
                "搭載されているGPUメモリの総量は"+gpuMemorySize+"MBです。\n搭載されているGPUの名前は"+ SystemInfo.graphicsDeviceName+"です。",
                "TEST",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
    }
}
