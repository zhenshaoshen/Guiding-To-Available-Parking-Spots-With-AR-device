using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform target3;

    private float moveSpeed = 5f;

    private void Start()
    {
        StartCoroutine(MoveToTargets());
    }

    private System.Collections.IEnumerator MoveToTargets()
    {
        yield return StartCoroutine(MoveToTarget(target1.position));
        yield return StartCoroutine(MoveToTarget(target2.position));
        yield return StartCoroutine(MoveToTarget(target3.position));

        // 所有目标位置都已经到达
    }

    private System.Collections.IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(transform.position, targetPosition);

        while (distance > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, targetPosition);
            yield return null;
        }
    }
}








































