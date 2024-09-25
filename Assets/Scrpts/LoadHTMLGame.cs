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
        // WebView2アプリケーションのパスと引数を設定
        //string webView2Path = "path_to_your_webview2_executable";
        //string arguments = "--url=\"https://your.url.here\"";
        arguments = Path.Combine(Application.dataPath, arguments);
        // プロセスを開始
        _webViewProcess = new Process();
        _webViewProcess.StartInfo.FileName = webView2Path;
        _webViewProcess.StartInfo.Arguments = arguments;
        _webViewProcess.StartInfo.UseShellExecute = false;
        _webViewProcess.StartInfo.CreateNoWindow = true;
        _webViewProcess.Start();

        // ウインドウハンドルを取得
        _webViewProcess.WaitForInputIdle();
        _webViewHandle = _webViewProcess.MainWindowHandle;

        // Unityのウインドウハンドルを取得
        IntPtr unityWindowHandle = GetForegroundWindow();

        // WebView2のウインドウをUnityのウインドウに埋め込む
        SetParent(_webViewHandle, unityWindowHandle);
        ShowWindow(_webViewHandle, 3); // SW_MAXIMIZE

        // ウインドウのスタイルを設定
        int style = GetWindowLong(_webViewHandle, -16); // GWL_STYLE
        SetWindowLong(_webViewHandle, -16, style & ~0x800000); // WS_CAPTIONを削除
    }

    void OnApplicationQuit()
    {
        // プロセスを終了
        if (_webViewProcess != null && !_webViewProcess.HasExited)
        {
            _webViewProcess.Kill();
        }
    }
}
