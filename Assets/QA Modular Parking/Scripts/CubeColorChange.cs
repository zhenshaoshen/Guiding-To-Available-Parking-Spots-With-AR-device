using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;


public class CubeColorChange : MonoBehaviour
{
    private Renderer Sensor1Renderer;
    private char getCode() {
        return Convert.ToChar(Convert.ToInt32('A') - 1 + Convert.ToInt32(gameObject.name.Replace("Sensor", "")));
    }

    void Start()
    {
        //gameObject.tag="Capsule";
        // 获取Sensor1的Renderer组件
        Sensor1Renderer = GetComponent<MeshRenderer>();
        Sensor1Renderer.material.color = Color.green;
        print("Sensor: " + gameObject.name + ", Code: "+ getCode());
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            // 撞击到Capsule时，将Sensor1的颜色设置为红色
            Sensor1Renderer.material.color = Color.red;
            //Debug.Log("color red");

            
            StartCoroutine(SendUpdateDataRequest("1"));
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Capsule离开时，将Sensor1的颜色设置为绿色
            Sensor1Renderer.material.color = Color.green;
            //Debug.Log("color green");
            StartCoroutine(SendUpdateDataRequest("0"));
        }
    }

    IEnumerator SendUpdateDataRequest(string isBusy)
    {
        string url = "http://20.65.176.40:2222/get_data?table=2";

        WWWForm formData = new WWWForm();
        formData.AddField("code", getCode().ToString());
        formData.AddField("busy", isBusy);

        using (UnityWebRequest www = UnityWebRequest.Post(url, formData))
        {
            yield return www.SendWebRequest();
            

            if (www.result == UnityWebRequest.Result.Success)
            {
                
                string response = www.downloadHandler.text;
                Debug.Log(response);
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
    }

}
