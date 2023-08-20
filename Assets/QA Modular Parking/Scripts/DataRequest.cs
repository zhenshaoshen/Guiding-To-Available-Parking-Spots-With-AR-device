using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataRequest : MonoBehaviour
{
    private string baseUrl = "http://20.65.176.40:2222/";
    private string table = "E"; // 表名
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
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
    }
}
