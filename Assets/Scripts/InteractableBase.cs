using UnityEngine;
using System.Collections;
using System;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    private Outline _outline;

    private Renderer renderer;
    private int anzahl = 0;
    Color[] colors;

    public Color HighlightColor = Color.blue;

    public void Start()
    {
        //_outline = GetComponent<Outline>();
        //_outline.enabled = false;
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
        SaveOriginalColors();
        HighlightObject();
    }

    private void SaveOriginalColors()
    {
        renderer = GetComponent<Renderer>();
        foreach (var m in renderer.materials)
        {
            anzahl++;
        }

        colors = new Color[anzahl];
        int index = 0;

        foreach (var mat in renderer.materials)
        {
            colors[index] = mat.color;
            index++;
        }
    }

    public void OnPointerExit()
    {
        //_outline.enabled = false;
        renderer = GetComponent<Renderer>();
        int index = 0;
        foreach (var mat in renderer.materials)
        {
            mat.color = colors[index];
            index++;
        }
    }

    private void HighlightObject()
    {
        //_outline.enabled = true;
        renderer = GetComponent<Renderer>();
        foreach (var mat in renderer.materials)
        {
            mat.color = HighlightColor;
        }
    }
    
    
}
