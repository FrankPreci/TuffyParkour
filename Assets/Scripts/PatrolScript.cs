using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrollingSpawner : MonoBehaviour
{
    public Transform PointA, PointB;
    public float patrolSpeed = 2f;        // Speed of movement along the X-axis
    Vector2 targetPosition;

    private void Start()
    {

        targetPosition = PointA.position;

    }
    // Method to move the spawner back and forth on the X-axis
    void Update()//Patrol Script
    {
        if (Vector2.Distance(transform.position, PointA.position) < .1f) { targetPosition = PointB.position; }
        if (Vector2.Distance(transform.position, PointB.position) < .1f) { targetPosition = PointA.position; }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, patrolSpeed*Time.deltaTime);
    }
}

