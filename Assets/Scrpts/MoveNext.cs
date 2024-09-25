using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MoveNext : MonoBehaviour
{
    public float speed;
    public int allObjects;//Objectの数
    public GameObject center;
    public int index;
    public int moveAngle;
    float moveSeconds;
    public float currentAngle;
    public bool isCoolTime;
    public bool isAppExited = true;//ゲームが閉じているか
    void Start()
    {
        index = 1025;
        moveAngle = 360/allObjects;
        moveSeconds = moveAngle/speed;
        currentAngle = 0f;
        isCoolTime = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)&&isCoolTime == true)
        {
            StartCoroutine(Move(-speed));
            index++;
            currentAngle = currentAngle+moveAngle;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)&&isCoolTime == true)
        {
            StartCoroutine(Move(speed));
            if(index == 0)
            {
                SceneManager.LoadScene("HideScene");
            }
            else{index--;}
            currentAngle = currentAngle-moveAngle;
        }
    }
    public IEnumerator Move(float speed)
    {
        float timer = 0f;
        while (timer < moveSeconds)
        {
            transform.RotateAround(center.transform.position,new Vector3(0,1,0), speed);
            timer ++;
            yield return null;
        }
    }
    /*async void Wait(int e)
    {
        await Task.Delay(e);
        isCoolTime = true;
    }*/
}