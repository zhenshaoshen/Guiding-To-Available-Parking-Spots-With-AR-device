using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhuan : MonoBehaviour
{
    int speed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up*speed);
    }
}
