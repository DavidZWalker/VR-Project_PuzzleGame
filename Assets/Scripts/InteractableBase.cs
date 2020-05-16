using UnityEngine;
using System.Collections;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{ 
    public void Start()
    { 
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
        // TODO: remove outline logic
    }

    private void HighlightObject()
    {
        // TODO: Changing color on material will not work for imported assets --> need outline logic here
    }
    
    
}
