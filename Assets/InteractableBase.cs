using UnityEngine;
using System.Collections;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    private Color originalColor;

    public Color HighlightColor = Color.blue;

    public abstract void Interact();

    public void OnPointerEnter()
    {
        HighlightObject();
    }

    public void OnPointerExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    private void HighlightObject()
    {
        var renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        renderer.material.color = HighlightColor;
    }
    
    
}
