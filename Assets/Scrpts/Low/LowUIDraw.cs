using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Forms;
using UnityEngine.SceneManagement;

public class LowUIDraw : MonoBehaviour
{
    public LightControll moveNext;
    public int index;
    public GameObject imageObject;
    public Image imageComponent;
    public Sprite[] spriteImage;
    void Start ()
    {
        imageComponent = imageObject.GetComponent<Image>();
    }
    void Update ()
    {
        index = moveNext.num;
        imageComponent.sprite = spriteImage[index];
    }
}
