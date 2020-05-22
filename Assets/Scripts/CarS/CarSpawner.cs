using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnInterval = 5f;
    public GameObject spawnObject;
    public GameObject spawnObject2;
    public GameObject spawnObject3;

    private GameObject nextSpawnedObject;

    private float secondsSinceLastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetNextSpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        var secondsSinceLastFrame = Time.deltaTime;
        secondsSinceLastSpawn += secondsSinceLastFrame;

        if (secondsSinceLastSpawn >= spawnInterval)
        {
            secondsSinceLastSpawn = 0;
            //Spawn Enemy
            Instantiate(nextSpawnedObject, transform.position, Quaternion.identity);
            SetNextSpawnObject();
        }

    }

    void SetNextSpawnObject()
    {
        System.Random random = new System.Random();
        int number = random.Next(3);
        if (number == 0)
        {
            nextSpawnedObject = spawnObject;
        }
        if (number == 1)
        {
            nextSpawnedObject = spawnObject2;
        }
        if (number == 2)
        {
            nextSpawnedObject = spawnObject3;
        }
    }
}
