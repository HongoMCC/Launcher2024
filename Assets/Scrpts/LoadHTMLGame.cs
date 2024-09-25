using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using UnityEngine;
using System.IO;

public class WebView : MonoBehaviour
{
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    private IntPtr _webViewHandle;
    private Process _webViewProcess;
    public string webView2Path;
    public string arguments;
    void Start()
    {
        // WebView2�A�v���P�[�V�����̃p�X�ƈ�����ݒ�
        //string webView2Path = "path_to_your_webview2_executable";
        //string arguments = "--url=\"https://your.url.here\"";
        arguments = Path.Combine(Application.dataPath, arguments);
        // �v���Z�X���J�n
        _webViewProcess = new Process();
        _webViewProcess.StartInfo.FileName = webView2Path;
        _webViewProcess.StartInfo.Arguments = arguments;
        _webViewProcess.StartInfo.UseShellExecute = false;
        _webViewProcess.StartInfo.CreateNoWindow = true;
        _webViewProcess.Start();

        // �E�C���h�E�n���h�����擾
        _webViewProcess.WaitForInputIdle();
        _webViewHandle = _webViewProcess.MainWindowHandle;

        // Unity�̃E�C���h�E�n���h�����擾
        IntPtr unityWindowHandle = GetForegroundWindow();

        // WebView2�̃E�C���h�E��Unity�̃E�C���h�E�ɖ��ߍ���
        SetParent(_webViewHandle, unityWindowHandle);
        ShowWindow(_webViewHandle, 3); // SW_MAXIMIZE

        // �E�C���h�E�̃X�^�C����ݒ�
        int style = GetWindowLong(_webViewHandle, -16); // GWL_STYLE
        SetWindowLong(_webViewHandle, -16, style & ~0x800000); // WS_CAPTION���폜
    }

    void OnApplicationQuit()
    {
        // �v���Z�X���I��
        if (_webViewProcess != null && !_webViewProcess.HasExited)
        {
            _webViewProcess.Kill();
        }
    }
}
