using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspets : MonoBehaviour
{
    public float targetAspect;
    Camera objectCamera;
    // Start is called before the first frame update
    void Start()
    {
        objectCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectCamera.aspect<targetAspect)
        {
            var horizontalSize = 1920*targetAspect;
            var verticalSize = horizontalSize / objectCamera.aspect;
            objectCamera.orthographicSize = verticalSize;
        }
    }
}
