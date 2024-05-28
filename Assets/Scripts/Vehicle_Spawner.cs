using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRand;
    [SerializeField] float vehicleSpeed;
    [SerializeField] Transform target;
    [SerializeField] GameObject[] vehicles;

    float timeSinceLastSpawn;
    void Start()
    {
        SpawnVehicle(vehicles[Random.Range(0, vehicles.Length - 1)]);
    }

    
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= spawnRate + Random.Range(-spawnRand, spawnRand))
        {
            timeSinceLastSpawn = 0;
            SpawnVehicle(vehicles[Random.Range(0, vehicles.Length - 1)]);
        }
    }

    void SpawnVehicle(GameObject go)
    {
        GameObject instance;
        instance = Instantiate(go, transform);
        instance.GetComponent<Title_Vehicle>().Activate(vehicleSpeed, target);
    }
}
