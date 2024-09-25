using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guide : MonoBehaviour
{
    public GameObject main;
    public GameObject target;
    private void Start()
    {
        target.SetActive(false);
    }
    void Update()
    {
        if(main.transform.localScale == Vector3.one)
        {
            target.SetActive(true);
        }
    }
}
