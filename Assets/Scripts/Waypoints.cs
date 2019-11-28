using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Con Fig Vars
    [Header("Way Points")]
    public List<Transform> waypoints = new List<Transform>();

    [Header("Parameters")]
    [SerializeField] float minDistance = 0.1f;

    // State Vars

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform GetTargetWaypoint(int targetWaypointIndex)
    {
        return waypoints[targetWaypointIndex];
    }

    public float GetMinDistaceToWaypoint()
    {
        return minDistance;
    }

    public int GetLastWaypointIndex()
    {
        return waypoints.Count - 1;
    }
}
