using UnityEngine;
using System.Collections;
using System;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    private int _anzahlColorsInKindObjekt = 10;
    Color[,] colors;

    public Color HighlightColor = Color.blue;

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
        SaveOriginalColors();
        HighlightObject();
    }

    private void SaveOriginalColors()
    {
        MeshRenderer[] kindObjekte = GetComponentsInChildren<MeshRenderer>();

        //zweidimensionales Array wird angelegt: [ Anzahl Kindobjekte , festgelegte Anzahl der Materials/Kind ]
        colors = new Color[kindObjekte.Length, _anzahlColorsInKindObjekt];

        //Schleife geht durch alle KindObjekte des Elternobjekts durch
        for (int i = 0; i < kindObjekte.Length; i++)
        {
            //Schleife geht durch alle Materials des KindObjekts durch und speichert diese im Array "colors"
            int index = 0;
            foreach (var mat in kindObjekte[i].materials)
            {
                colors[i, index] = mat.color;
                index++;
            }
        }
    }

    private void HighlightObject()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            foreach (var mat in renderers[i].materials)
            {
                mat.color = HighlightColor;
            }            
        }
    }

    public void OnPointerExit()
    {
        MeshRenderer[] kindObjekte = GetComponentsInChildren<MeshRenderer>();
        //Schleife geht durch alle KindObjekte des Elternobjekts durch
        for (int i = 0; i < kindObjekte.Length; i++)
        {
            //Schleife geht durch alle Materials des KindObjekts durch und setzt sie auf die Originalfarbe zurück
            int index = 0;
            foreach (var mat in kindObjekte[i].materials)
            {
                mat.color = colors[i, index];
                index++;
            }
        }

    }
}
