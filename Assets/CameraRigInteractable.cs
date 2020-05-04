﻿using UnityEngine;
using System.Collections;

public class CameraRigInteractable : InteractableBase
{
    private bool _isSwitching;

    public float CameraMovementSpeed = 10f;

    public override void Interact()
    {
        _isSwitching = false;
        SwitchCamera();
    }

    public void Update()
    {
        if (_isSwitching) MoveCameraTowardsTarget();
    }

    private void MoveCameraTowardsTarget()
    {
        // Calculate distance to move based on move-speed and time since last frame
        float distance = CameraMovementSpeed * Time.deltaTime;

        // Get the camera rig to move & the target location
        var cameraRig = GameObject.Find("Camera Rig");
        var targetCamAnchor = transform.GetChild(0);

        // Calculate and set new position
        cameraRig.transform.position = Vector3.MoveTowards(cameraRig.transform.position, targetCamAnchor.position, distance);

        // Stop moving if the target position has been reached
        if (Vector3.Distance(cameraRig.transform.position, targetCamAnchor.position) < 0.001f)
            StopMoving();
    }

    private void StopMoving()
    {
        _isSwitching = false;
    }

    private void SwitchCamera()
    {
        _isSwitching = true;
    }
}
