using UnityEngine;
using System.Collections;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    private Outline _outline;

    public void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
        InternalStart();
    }

    public void Update()
    {
        InternalUpdate();
    }

    public abstract void InternalStart();

    public abstract void InternalUpdate();

    public abstract void Interact();

    public void OnPointerEnter()
    {
        HighlightObject();
    }

    public void OnPointerExit()
    {
        _outline.enabled = false;
    }

    private void HighlightObject()
    {
        _outline.enabled = true;
    }
    
    
}
