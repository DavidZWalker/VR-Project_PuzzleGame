using UnityEngine;
using System.Collections;

public class LightSwitchInteractable : InteractableBase
{
    private Light _light;
    private bool _isOn;

    public void Start()
    {
        _light = GetComponentInChildren<Light>();
        _isOn = _light.enabled;
    }

    public override void Interact()
    {
        _isOn = !_isOn;
        _light.enabled = _isOn;
    }
}
