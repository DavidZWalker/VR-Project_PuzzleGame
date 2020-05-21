using UnityEngine;

public class DoorInteractable : InteractableBase
{
    private Animator _animator;
    private bool _isOpen = false;
    private AudioSource _audioSource;

    public bool isLocked;
    public string keyName;
    public AudioClip unlockDoorAudioClip;
    public AudioClip openDoorAudioClip;

    public override void Interact()
    {
        if (isLocked)
            TryUnlock();
        else
        {
            _isOpen = !_isOpen;
            _animator.SetBool("open", _isOpen);
            if (_isOpen)
            {
                _audioSource.PlayOneShot(openDoorAudioClip);
            }
        }
    }

    public override void InternalStart()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void InternalUpdate()
    {

    }

    private void TryUnlock()
    {
        var key = Inventory.Instance.GetItem(keyName);
        if (key != null)
        {
            Inventory.Instance.UseItem(key);
            Unlock();
        }
    }

    private void Unlock()
    {
        isLocked = false;
        _audioSource.PlayOneShot(unlockDoorAudioClip);
    }
}