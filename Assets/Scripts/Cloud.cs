using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _spawnLocationValue;
    private float _movedDistance;
    private static WindDirections _windDirection;
    private static float _windSpeed;

    public float travelDistance;

    // Start is called before the first frame update
    void Start()
    {
        _spawnLocationValue = _windDirection == WindDirections.X || _windDirection == WindDirections.NegativeX ?
            transform.position.x : transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPos = transform.position;
        var frameTravelDistance = _windSpeed * Time.deltaTime;
      
        // Depending on the current wind direction, the cloud should move in the corresponding direction
        switch (_windDirection)
        {
            case WindDirections.X:
                if (currentPos.x >= _spawnLocationValue + travelDistance)
                {
                    Destroy(gameObject);
                    return;
                }

                currentPos.x += frameTravelDistance;
                break;
            case WindDirections.NegativeX:
                if (currentPos.x <= _spawnLocationValue - travelDistance)
                {
                    Destroy(gameObject);
                    return;
                }

                currentPos.x -= frameTravelDistance;
                break;
            case WindDirections.Z:
                if (currentPos.z >= _spawnLocationValue + travelDistance)
                {
                    Destroy(gameObject);
                    return;
                }

                currentPos.z += frameTravelDistance;
                break;
            case WindDirections.NegativeZ:
                if (currentPos.z <= _spawnLocationValue - travelDistance)
                {
                    Destroy(gameObject);
                    return;
                }

                currentPos.z -= frameTravelDistance;
                break;
        }

        transform.position = currentPos;
        _movedDistance += frameTravelDistance;
    }

    public static void SetWindDirection(WindDirections direction)
    {
        _windDirection = direction;
    }

    public static void SetWindSpeed(float speed)
    {
        _windSpeed = speed;
    }
}
