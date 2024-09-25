using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDraw : MonoBehaviour
{
    public MoveNext moveNext;
    public int index;
    public bool isDisplay;
    public GameObject imageObject;
    public Image imageComponent;
    public Sprite[] spriteImage;
    public GameObject buttonObject;
    public Image buttonComponent;
    public Sprite[] buttonImage;
    public GameObject intro;
    void Start ()
    {
        imageComponent = imageObject.GetComponent<Image>();
        buttonComponent = buttonObject.GetComponent<Image>();
        isDisplay = true;
    }
    void Update ()
    {
        index = moveNext.index;
        if(isDisplay == true)
        {
            imageComponent.sprite = spriteImage[(index%(moveNext.allObjects))];//わりかし脳筋なのでspriteImage[0]にはallObjectsのをいれる
            buttonComponent.sprite = buttonImage[0];
            intro.SetActive(true);
        }
        if(isDisplay == false)
        {
            buttonComponent.sprite = buttonImage[1];
            intro.SetActive(false);
        }
    }
    public void OnClick ()
    {
        isDisplay = !isDisplay;
        /*if(isDisplay == true)
        {
            isDisplay = false;
        }
        if(isDisplay == false)
        {
            isDisplay = true;
        }*/
    }
}
