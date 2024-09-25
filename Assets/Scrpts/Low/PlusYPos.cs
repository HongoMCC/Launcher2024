using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusYPos : MonoBehaviour
{
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(0.0f, y, 0.0f);
    }
}
