using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public int timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(Input.anyKey)
        {
            this.gameObject.SetActive(false);
        }
        if(timer > 1200)
        {
            Application.Quit();
        }
    }
}
