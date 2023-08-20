/*
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.AI;

public class NavPathArrow : MonoBehaviour {

    private NavMeshAgent _navPlayer;

    private NavMeshPath _navPath;

    public float tileSpacing = 0.5f;

    public LineRenderer lineGameObject;

    public GameObject directionPrefab;

    private List<GameObject> arrowList = new List<GameObject>();

    // Use this for initialization

    void Start () {

        _navPlayer = transform.GetComponent<NavMeshAgent>();

        _navPath = new NavMeshPath();

    }

    // Update is called once per frame

    void Update () {

                if(Input.GetMouseButtonDown(0)) {

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hit;

                    if(Physics.Raycast(ray,out hit,Mathf.Infinity)) {

                                print ("hit :" + hit.point);

                                _navPlayer.SetDestination(hit.point);

                        NavMesh.CalculatePath(transform.position, hit.point, NavMesh.AllAreas, _navPath);

                                DrawPath(_navPath);

                    }

                }

    }

    /// <summary>

    /// Draws the path.

    /// </summary>

    /// <param name="navPath">Nav path.</param>

    void DrawPath(NavMeshPath navPath)

    {

        List<GameObject> arrows = arrowList;

        StartCoroutine(ClearArrows(arrows));

        arrowList.Clear();

        //If the path has 1 or no corners, there is no need to draw the line

        if (navPath.corners.Length < 2)

        {

            print ("navPath.corners.Length < 2");

            return;

        }

        // Set the array of positions to the amount of corners...

        lineGameObject.positionCount = navPath.corners.Length;

        Quaternion planerot = Quaternion.identity;

        for (int i = 0; i < navPath.corners.Length; i++)

        {

            // Go through each corner and set that to the line renderer's position...

            lineGameObject.SetPosition(i, navPath.corners[i]);

            float distance = 0;

            Vector3 offsetVector = Vector3.zero;

            if (i < navPath.corners.Length - 1)

            {

                //plane rotation calculation

                offsetVector = navPath.corners[i + 1] - navPath.corners[i];

                planerot = Quaternion.LookRotation(offsetVector);

                distance = Vector3.Distance(navPath.corners[i + 1], navPath.corners[i]);

                if (distance < tileSpacing)

                    continue;

                planerot = Quaternion.Euler(90, planerot.eulerAngles.y, planerot.eulerAngles.z);

                //plane position calculation

                float newSpacing = 0;

                for (int j = 0; j < distance / tileSpacing; j++)

                {

                    newSpacing += tileSpacing;

                    var normalizedVector = offsetVector.normalized;

                    var position = navPath.corners[i] + newSpacing * normalizedVector;

                    GameObject go = Instantiate(directionPrefab, position+Vector3.up, planerot);

                    arrowList.Add(go);

                }

            }

            else

            {

                GameObject go = Instantiate(directionPrefab, navPath.corners[i]+Vector3.up, planerot);

                arrowList.Add(go);

            }

        }

    }

    /// <summary>

    /// Clears the arrows.

    /// </summary>

    /// <returns>The arrows.</returns>

    /// <param name="arrows">Arrows.</param>

    private IEnumerator ClearArrows(List<GameObject> arrows)

    {

        if (arrowList.Count == 0)

            yield break;

        foreach (var arrow in arrows)

            Destroy(arrow);

    }

}

*/