using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class MarkNumbering : MonoBehaviour
{
    private int getCode() 
    {
        return Convert.ToInt32(gameObject.name.Replace("Mark", ""));
    }
    // Start is called before the first frame update
    void Start()
    {
        print("Mark: " + gameObject.name + ", Code: "+ getCode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
