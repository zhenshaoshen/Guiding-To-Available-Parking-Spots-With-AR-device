using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataRequest4 : MonoBehaviour
{
    private string baseUrl = "http://20.65.176.40:2222/";
    private string table = "4"; // 表名
    private string license = "007"; // 车牌号

    private void Start()
    {
        StartCoroutine(GetDataRequest());
    }

    IEnumerator GetDataRequest()
    {
        string url = $"{baseUrl}get_data?table={table}&license={license}";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string response = www.downloadHandler.text;
                Debug.Log(response); // 这里是从服务器获取到的数据，你可以在这里进行处理
                /*
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                string data = reader.ReadLine();
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(parsedDestination);*/
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
    }
}

/*
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataRequest4 : MonoBehaviour
{
    private string url = "http://20.65.176.40:1234/get_data?table=4"; // 请根据你的服务器地址和路由进行修改

    private void Start()
    {
        StartCoroutine(GetDataRequest());
    }

    IEnumerator GetDataRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string response = www.downloadHandler.text;
                Debug.Log(response); // 这里是从服务器获取到的数据，你可以在这里进行处理
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
    }
}*/