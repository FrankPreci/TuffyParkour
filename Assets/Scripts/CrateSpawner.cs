using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public float spawnInterval = 2f; // Time between spawns
    private float timeSinceLastSpawn = 0f;
    public Transform PointA, PointB;
    public float patrolSpeed = 2f;        // Speed of movement along the X-axis
    Vector2 targetPosition;
    public bool isSpawning = false;
    private void Start()
    {
        targetPosition = PointA.position;
    }
    void Update()
    {
        // Update the time since the last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // If enough time has passed, spawn a new object
        if (timeSinceLastSpawn >= spawnInterval && isSpawning)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f; // Reset timer
        }

        //patrol script
        if (Vector2.Distance(transform.position, PointA.position) < .1f) {
            targetPosition = PointB.position; 
            isSpawning = true;
        }
        if (Vector2.Distance(transform.position, PointB.position) < .1f) {
            targetPosition = PointA.position; 
            isSpawning = false ;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);
    }

    void SpawnObject()
    {
        // Instantiate the object at the spawner's position
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

}


