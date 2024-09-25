using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabegamisize : MonoBehaviour
{

    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rectTransform = GetComponent<RectTransform>();//対象のオブジェクトにアタッチ
        float screenRatio = (float)width / height;
        // 縦幅を解像度の縦幅に一致させる
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        // 横幅を縦幅とターゲット比率で設定
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
