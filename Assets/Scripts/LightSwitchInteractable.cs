using UnityEngine;
using System.Collections;

public class LightSwitchInteractable : InteractableBase
{
    private Light _light;
    private bool _isOn;
    
    public override void Interact()
    {
        _isOn = !_isOn;
        _light.enabled = _isOn;
    }

    public override void InternalStart()
    {
        _light = GetComponentInChildren<Light>();
        _isOn = _light.enabled;
    }

    public override void InternalUpdate()
    {
        
    }
}
