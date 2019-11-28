using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRail : MonoBehaviour
{
    // Con Fig Vars
    [SerializeField] bool loop = true;
    [SerializeField] Waypoints circuit;
    [SerializeField] int startingWaypoint = 1;
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] float rotationSpeed = 10.0f;

    // State Vars
    private Transform targetWaypoint;
    private int targetWaypointIndex;
    private float minDistance;
    private int lastWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        InitializePathing();
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
    }

    private void InitializePathing()
    {
        if (!circuit) return;

        lastWaypointIndex = circuit.GetLastWaypointIndex();
        targetWaypointIndex = startingWaypoint - 1;

        if (targetWaypointIndex < 0 || targetWaypointIndex > lastWaypointIndex)
        {
            Debug.LogError("Target Way Point Index is out of range: Resetting to 0");
            targetWaypointIndex = 0;
        }

        targetWaypoint = circuit.GetTargetWaypoint(targetWaypointIndex);
        minDistance = circuit.GetMinDistaceToWaypoint();
    }

    private void ManageMovement()
    {
        if (!circuit) return;

        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f);
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f);

        float distance = Vector3.Distance(transform.position,
            targetWaypoint.position);

        transform.position = Vector3.MoveTowards(transform.position,
            targetWaypoint.position, movementStep);

        CheckDistanceToWaypoint(distance);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex && !loop) targetWaypointIndex = lastWaypointIndex;
        if (targetWaypointIndex > lastWaypointIndex) targetWaypointIndex = 0;
        targetWaypoint = circuit.GetTargetWaypoint(targetWaypointIndex);
    }
}
