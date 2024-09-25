using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextsControll : MonoBehaviour
{
   public TMP_Text text;
    public CallApps callApps;
    public int index;
    string readmepath;
    string readMeMes;
    void Start()
    {
        index = callApps.index;
        readmepath = callApps.readmePath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
