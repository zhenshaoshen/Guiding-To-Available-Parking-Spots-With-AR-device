using UnityEngine;

public class Sensor1Numbering : MonoBehaviour
{
    public string Sensor1Number = "A";

    void Start()
    {
        // 输出编号
        Debug.Log("Sensor1 Number: " + Sensor1Number);
    }
}
