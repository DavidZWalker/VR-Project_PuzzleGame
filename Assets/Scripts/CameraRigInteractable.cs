using UnityEngine;
using System.Collections;

public class CameraRigInteractable : InteractableBase
{
    private bool _isSwitching;
    private Vector3 _objectVector;

    public float CameraMovementSpeed = 10f;

    public override void Interact()
    {
        _isSwitching = false;
        SwitchCamera();
    }

    private void MoveCameraTowardsTarget()
    {
        // Calculate distance to move based on move-speed and time since last frame
        float distance = CameraMovementSpeed * Time.deltaTime;

        // Get the camera rig to move & the target location
        var cameraRig = GameObject.Find("Camera Rig");
        var targetCamAnchor = transform.Find("CameraAnchor");

        // Calculate and set new position
        cameraRig.transform.position = Vector3.MoveTowards(cameraRig.transform.position, targetCamAnchor.position, distance);

        // Stop moving if the target position has been reached
        if (Vector3.Distance(cameraRig.transform.position, targetCamAnchor.position) < 0.001f)
            StopMoving();
    }

    private void StopMoving()
    {
        _isSwitching = false;
        MakeBlockVisibleAgain();
    }

    private void SwitchCamera()
    {
        _isSwitching = true;
        _objectVector = gameObject.transform.localScale;
        MakeBlockInvisible();
    }

    private void MakeBlockVisibleAgain()
    {
        gameObject.transform.localScale = _objectVector;
    }

    private void MakeBlockInvisible()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public override void InternalStart()
    {
        
    }

    public override void InternalUpdate()
    {
        if(_isSwitching) MoveCameraTowardsTarget();
    }
}
