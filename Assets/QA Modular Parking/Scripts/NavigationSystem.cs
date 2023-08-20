using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 导航系统脚本
public class NavigationSystem : MonoBehaviour
{
    private int nextDestination;

    // 导航到下一个目标点
    private void NavigateToNextDestination()
    {
        // 根据物体编号找到目标点
        GameObject destination = GameObject.Find("Object" + nextDestination.ToString());

        // 如果找到目标点，则将其位置设置为导航系统的下一个目标点
        if (destination != null)
        {
            GetComponent<NavMeshAgent>().SetDestination(destination.transform.position);
        }
        else
        {
            Debug.LogError("目标点未找到！");
        }
    }

    // 接收服务器发送的物体编号
    public void ReceiveObjectNumber(int objectNumber)
    {
        nextDestination = objectNumber;
        NavigateToNextDestination();
    }
}

// 服务器通信脚本
public class ServerCommunication : MonoBehaviour
{
    // 当接收到服务器发送的消息时调用
    private void OnMessageReceived(string message)
    {
        // 解析消息，获取物体编号
        int objectNumber = int.Parse(message);

        // 导航系统接收到物体编号
        FindObjectOfType<NavigationSystem>().ReceiveObjectNumber(objectNumber);
    }
}
