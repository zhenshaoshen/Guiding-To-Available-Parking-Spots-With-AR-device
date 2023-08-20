using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

// 请确保 MiniJSON.cs 文件与 PlayerMove.cs 文件在同一目录下或正确引用
using MiniJSON; // Add the correct namespace here

public class PlayerMove1 : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Vector3 targetPosition;

    

    private IEnumerator Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://20.65.176.40:2222/get_data?table=E"))
        {
            yield return webRequest.SendWebRequest();

            

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string serverResponse = webRequest.downloadHandler.text;
                Debug.Log("Server Response: " + serverResponse);

                // 解析服务器返回的 JSON 数据
                Dictionary<string, object> jsonData = Json.Deserialize(serverResponse) as Dictionary<string, object>;

                if (jsonData != null && jsonData.ContainsKey("x") && jsonData.ContainsKey("y"))
                {
                    float x = Convert.ToSingle(jsonData["x"]);
                    float z = Convert.ToSingle(jsonData["y"]);

                    targetPosition = new Vector3(x, 0, z);
                    navMeshAgent.SetDestination(targetPosition);
                }

                
                else
                {
                    Debug.LogError("Invalid or missing data in the server response.");
                }


            }
            else
            {
                Debug.LogError("Failed to retrieve data from the server. Result: " + webRequest.result);
            }
        }
    }


     private void Update()
    {
    }
}