using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public class SampleWebviewObject : MonoBehaviour
{
    private WebViewObject webViewObject;
    public const string url = "https://www.google.co.jp";

    // Use this for initialization
    void Start()
    {
        // WebViewObject�̐���
        this.webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();

        //�}�[�W�������߂�
        int mX = Screen.width / 9;
        int mY = Screen.height / 5;

        // �L���b�V�����p�^�C���X�^���v
        //string date = '?'+DateTime.Now.ToString();


        // �R�[���o�b�N�ݒ�
        this.webViewObject.Init((msg) =>
        {
            switch (msg)
            {
                case "�V�[����":

                    // WebView�̒�~

                    this.webViewObject.SetVisibility(false);
                    Destroy(this.webViewObject);

                    //�V�[���̑J��
                    SceneManager.LoadScene(msg);
                    break;

                case "close":
                    // WebView�̒�~
                    this.webViewObject.SetVisibility(false);
                    Destroy(this.webViewObject);

                    Destroy(GameObject.Find("WebViewObjectOrigin(Clone)").gameObject);
                    break;
            }
        });

        // URL�̐ݒ�
        this.webViewObject.LoadURL(url);

        // �}�[�W��(�]��)�̐ݒ�
        this.webViewObject.SetMargins(mX, mY, mX, mY);

        // WebView��L���ɂ���
        this.webViewObject.SetVisibility(true);
    }*/