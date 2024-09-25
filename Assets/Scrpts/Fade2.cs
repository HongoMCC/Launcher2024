using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fade2 : MonoBehaviour
{
    public float fadeSpeed; // フェード速度指定
    public Sprite[] sprites;
    public Color color;
    public bool isFadeOut;
    public bool isFadeIn;
    public float time;
    public bool isEnable;
    //public bool isBehind;//レイヤーが手前のGameObject（デフォでfalse）はこれを入れる

    // Start is called before the first frame update
    private void OnEnable()
    {
        this.gameObject.GetComponent<Image>().sprite = sprites[(int)(Random.Range(0, sprites.Length - 1))];
        gameObject.GetComponent<Image>().color = color;
        color.a = 0;
        isFadeIn = true;
        time = 0;
        color = this.gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 6f)
        {
            isFadeOut = true;
            time = 0;
        }
        //条件を満たしたらフェードアウト
        if (isFadeOut)
        {
            color.a -= fadeSpeed;
            gameObject.GetComponent<Image>().color = color;
            //暗くなった
            if (color.a <= 0)
            {
                this.gameObject.SetActive(false);
                isFadeOut = false;
            }
        }
        if(isFadeIn)
        {
            color.a += fadeSpeed;
            gameObject.GetComponent<Image>().color = color;
            time = 0;
            if (color.a >= 1.0f)
            {
                color.a = 1.0f;
                isFadeIn = false;
                isEnable = true;
            }
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
