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
        // GPU�̖��O�ƃ������e�ʂ����O�ɏo��
        Debug.Log("GPU Name: " + SystemInfo.graphicsDeviceName);
        Debug.Log("GPU Memory Size: " + gpuMemorySize + " MB");
        MessageBox.Show
            (
                "���ڂ���Ă���GPU�������̑��ʂ�"+gpuMemorySize+"MB�ł��B\n���ڂ���Ă���GPU�̖��O��"+ SystemInfo.graphicsDeviceName+"�ł��B",
                "TEST",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
    }
}
