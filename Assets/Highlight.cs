using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Color HighlightColor = Color.blue;
    private Color originalColor;

    public void HighlightObject()
    {
        var renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        renderer.material.color = HighlightColor;
    }

    public void Reset()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
}
