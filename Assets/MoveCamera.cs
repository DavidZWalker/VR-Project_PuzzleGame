using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public void SwitchCamera()
    {
        var cameraRig = GameObject.Find("Camera Rig");
        var targetCamAnchor = transform.GetChild(0);
        cameraRig.transform.position = targetCamAnchor.position;
        cameraRig.transform.rotation = targetCamAnchor.rotation;
    }
}
