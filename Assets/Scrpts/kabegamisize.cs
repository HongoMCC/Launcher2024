using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabegamisize : MonoBehaviour
{

    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        RectTransform rectTransform = GetComponent<RectTransform>();//�Ώۂ̃I�u�W�F�N�g�ɃA�^�b�`
        float screenRatio = (float)width / height;
        // �c�����𑜓x�̏c���Ɉ�v������
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        // �������c���ƃ^�[�Q�b�g�䗦�Őݒ�
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
