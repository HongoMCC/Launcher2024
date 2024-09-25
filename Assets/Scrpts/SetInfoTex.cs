using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInfoTex : MonoBehaviour
{
    RectTransform rectTransform;
    public int heightBairitu;
    private void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;
        float posHeight = height / heightBairitu;
        rectTransform.anchoredPosition = new Vector2(0,posHeight);
    }
}
