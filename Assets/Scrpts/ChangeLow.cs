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
    // �`�F�b�N����FPS�̂������l�i20FPS�j
    public float fpsThreshold = 20f;

    // FPS�̌v�Z�Ɏg���ϐ�
    private float deltaTime = 0.0f;
    float fps;
    private void Start()
    {
        StartCoroutine(CheckFPS());
    }
    void Update()
    {
        // FPS���v�Z����
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        if(UnityEngine.Input.GetKeyUp(KeyCode.Escape))
        {
            var result = MessageBox.Show
                        (
                            "���g����PC�͖{�A�v���̓�������𖞂����Ă��Ȃ��\��������܂��B\n�S20��i�̂����A15��i�͓�������𖞂����Ă��Ȃ��Ă����g�p�����܂��B\n�uOK�v�������Ɖ��K�ɂ��g�p�����郉���`���[���N�����܂��B\n�uNO�v�������ƌ��݂̂܂܂ő��s���܂��B",
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
                            "���g����PC�͖{�A�v���̓�������𖞂����Ă��Ȃ��\��������܂��B\n�S20��i�̂����A15��i�͓�������𖞂����Ă��Ȃ��Ă����g�p�����܂��B\n�uOK�v�������Ɖ��K�ɂ��g�p�����郉���`���[���N�����܂��B\n�uNO�v�������ƌ��݂̂܂܂ő��s���܂��B",
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
