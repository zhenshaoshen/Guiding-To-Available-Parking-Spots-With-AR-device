/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ServerCommunication : MonoBehaviour
{
    private string serverURL = "http://20.65.176.40:1234/update_data"; // 替换为你的服务器URL

    public void SendDataToServer(Dictionary<string, object> data)
    {
        StartCoroutine(SendRequest(data));
    }

    private IEnumerator SendRequest(Dictionary<string, object> data)
    {
        // 将字典数据转换为JSON字符串
        string jsonData = JsonUtility.ToJson(data);

        // 创建一个字节数组，将JSON字符串转换为字节数组
        byte[] byteData = Encoding.UTF8.GetBytes(jsonData);

        // 创建一个Web请求
        WWWForm form = new WWWForm();
        form.AddBinaryData("data", byteData);

        // 发送请求到服务器
        using (WWW www = new WWW(serverURL, form))
        {
            yield return www;

            if (www.error != null)
            {
                Debug.LogError("Error sending data to server: " + www.error);
            }
            else
            {
                Debug.Log("Data sent to server successfully");
            }
        }
    }
}*/
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
public class HttpExample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SendUpdateDataRequest());
    }

    IEnumerator SendUpdateDataRequest()
    {
        string url = "http://20.65.176.40:1234/update_data";

        WWWForm formData = new WWWForm();
        formData.AddField("code", "A");
        formData.AddField("busy", "0");

        using (UnityWebRequest www = UnityWebRequest.Post(url, formData))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string response = www.downloadHandler.text;
                Debug.Log(response); // Display the response from the server
                /*void Start(){
                    // 订阅事件处理方法
                    CubeColorChange.OnNumberChanged += HandleNumberChanged;
                }
                void OnDestroy(){
                    // 在脚本销毁时取消订阅事件，以防止内存泄漏
                    CubeColorChange.OnNumberChanged -= HandleNumberChanged;
                }
                void HandleNumberChanged(int number) {
                    formData.AddField("busy", "1");
                    
                    // 在这里可以进行传递数字后的相应操作
                    }*/
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
    }
}