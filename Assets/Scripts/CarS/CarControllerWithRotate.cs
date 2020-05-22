using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerWithRotate : MonoBehaviour
{
    public float _movementSpeed = 5f;
    public Vector3 _targetPosition;
    private Vector3 _currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 180f, 0f);
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
