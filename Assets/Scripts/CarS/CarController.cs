using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float _movementSpeed = 5f;
    public Vector3 _targetPosition;
    private Vector3 _currentPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var timeSinceLastFrame = Time.deltaTime;
        _currentPosition = transform.position;

        transform.position = Vector3.MoveTowards(_currentPosition, _targetPosition, _movementSpeed * timeSinceLastFrame);

        if (_currentPosition == _targetPosition)
        {
            Destroy(gameObject);
        }

    }
}
