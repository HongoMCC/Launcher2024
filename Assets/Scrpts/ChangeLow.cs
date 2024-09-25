using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Windows.Forms;
using UnityEngine.Windows;
using System.Threading.Tasks;

public class ChangeLow : MonoBehaviour
{
    public MoveNext moveNext;
    // チェックするFPSのしきい値（20FPS）
    public float fpsThreshold = 20f;

    // FPSの計算に使う変数
    private float deltaTime = 0.0f;
    float fps;
    private void Start()
    {
        StartCoroutine(CheckFPS());
    }
    void Update()
    {
        // FPSを計算する
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        if(UnityEngine.Input.GetKeyUp(KeyCode.Escape))
        {
            var result = MessageBox.Show
                        (
                            "お使いのPCは本アプリの動作条件を満たしていない可能性があります。\n全20作品のうち、15作品は動作条件を満たしていなくてもご使用頂けます。\n「OK」を押すと快適にご使用頂けるランチャーを起動します。\n「NO」を押すと現在のままで続行します。",
                            "Hongo MCC 2024",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning
                        );
            switch (result)
            {
                case DialogResult.OK:
                    SceneManager.LoadScene("low");
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

    }
    IEnumerator CheckFPS()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            if(moveNext.isAppExited)
            {
                if (fps < fpsThreshold || UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                {
                    var result = MessageBox.Show
                        (
                            "お使いのPCは本アプリの動作条件を満たしていない可能性があります。\n全20作品のうち、15作品は動作条件を満たしていなくてもご使用頂けます。\n「OK」を押すと快適にご使用頂けるランチャーを起動します。\n「NO」を押すと現在のままで続行します。",
                            "Hongo MCC 2024",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning
                        );
                    switch (result)
                    {
                        case DialogResult.OK:
                            SceneManager.LoadScene("low");
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }
        }
    }
}
