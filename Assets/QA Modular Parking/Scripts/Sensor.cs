using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MyProjectNamespace;
/**
 * Class for storing extra info of each sensors 
 */
public class Sensor : MonoBehaviour
{
    public int floorNum = 1;
    public String id;
    public double x;
    public double y;
    public double height;

    // Start is called before the first frame update
    void Start()
    {
        this.id = gameObject.name;
        this.x = gameObject.transform.position.x; 
        this.y = gameObject.transform.position.z;
        this.height = gameObject.transform.position.y;
        this.floorNum = this.height <= 7.5 ? 1 : 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision) {
        print("collided");
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag=="Player") {
            PlayerMove scriptToAccess = other.gameObject.GetComponent<PlayerMove>();
            //scriptToAccess.goToNextTarget();
        }
    }
}
