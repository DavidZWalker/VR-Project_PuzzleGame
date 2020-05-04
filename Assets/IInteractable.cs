using UnityEngine;
using System.Collections;

public interface IInteractable
{
    void OnPointerEnter();

    void OnPointerExit();

    void Interact();
}
