using UnityEngine;

public class DoorInteractable : InteractableBase
{
    private Animator _animator;
    private bool _isOpen = false;

    public override void Interact()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("open", _isOpen);
    }

    public override void InternalStart()
    {
        _animator = GetComponent<Animator>();
    }

    public override void InternalUpdate()
    {
        
    }
}