using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    private float _secondsSinceLastCloudSpawn;

    public float spawnInterval;
    public float yRange = 20;
    public float xRange = 40;
    public float zRange = 40;
    public List<GameObject> cloudPrefabs;
    public WindDirections windDirection;
    public float windSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _secondsSinceLastCloudSpawn += Time.deltaTime;
        if (_secondsSinceLastCloudSpawn >= spawnInterval)
        {
            SpawnRandomCloud();
            _secondsSinceLastCloudSpawn = 0;
        }
    }

    /// <summary>
    /// Spawns a cloud chosen randomly from the list of available prefabs at a random
    /// location within the range parameters
    /// </summary>
    private void SpawnRandomCloud()
    {
        var spawnerPos = transform.position;
        var spawnX = Random.Range(spawnerPos.x - xRange, spawnerPos.x + xRange);
        var spawnY = Random.Range(spawnerPos.y - yRange, spawnerPos.y + yRange);
        var spawnZ = Random.Range(spawnerPos.z - zRange, spawnerPos.z + zRange);
        var spawnVector = new Vector3(spawnX, spawnY, spawnZ);
        var cloudObj = cloudPrefabs[Random.Range(0, cloudPrefabs.Count - 1)];
        Cloud.SetWindDirection(windDirection);
        Cloud.SetWindSpeed(windSpeed);
        Instantiate(cloudObj, spawnVector, Quaternion.identity);
    }
}
