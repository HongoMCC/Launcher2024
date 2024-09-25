using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour//�ς��Ȃ���
{
    public float fadeSpeed; // �t�F�[�h���x�w��
    public Sprite[] sprites;
    public bool isFadeOut;
    public bool isFadeIn;
    public float time;
    public GameObject other;
    public bool isBehind;//���C���[����O��GameObject�i�f�t�H��false�j�͂��������
    bool isactive;
    public Fade2 Fade2;

    // Start is called before the first frame update
    private void Start()
    {
        other.SetActive(true);
    }
    private void OnEnable()
    {
        this.gameObject.GetComponent<Image>().sprite = sprites[(int)(Random.Range(0, sprites.Length - 1))];
        time = 0;
        isactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 6f)
        {
            if(!other.activeSelf)
            {
                other.SetActive(true);
            }
            time = 0;
        }
        if (Fade2.isEnable)
        {
            this.gameObject.GetComponent<Image>().sprite = sprites[(int)(Random.Range(0, sprites.Length - 1))];
            Fade2.isEnable = false;
        }
    }

    /*void FadeIn()
    {
        if (me.GetComponent<Image>().color.a < 255)
        {
            UnityEngine.Color tmp = me.GetComponent<Image>().color;
            tmp.a = tmp.a + (Time.deltaTime * fadeSpeed);
            me.GetComponent<Image>().color = tmp;
        }
    }*/
}
