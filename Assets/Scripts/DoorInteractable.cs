using UnityEngine;

public class DoorInteractable : InteractableBase
{
    private Animator _animator;
    private bool _isOpen = false;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("open", _isOpen);
    }
}