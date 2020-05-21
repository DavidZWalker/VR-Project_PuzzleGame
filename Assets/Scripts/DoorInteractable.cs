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
    public AudioClip closeDoorAudioClip;
    public AudioClip doorLockedAudioClip;

    public override void Interact()
    {
        // if the door is locked, try to unlock it first
        if (isLocked)
            TryUnlock();
        else
        {
            // start the open/close animation and play the audio
            _isOpen = !_isOpen;
            _animator.SetBool("open", _isOpen);

            // avoid using PlayOneShot() here because the current clip needs to be stopped if it is currently playing
            // e.g. when opening and then immediately closing the door
            _audioSource.Stop();
            _audioSource.clip = _isOpen ? openDoorAudioClip : closeDoorAudioClip;
            _audioSource.Play();
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
        // check whether the corresponding key is currently in the player's inventory
        var key = Inventory.Instance.GetItem(keyName);
        if (key != null)
        {
            // if player has the key, use it and unlock the door
            Inventory.Instance.UseItem(key);
            Unlock();
        }
        else
            _audioSource.PlayOneShot(doorLockedAudioClip); // if player does not have key, play special audio clip
    }

    private void Unlock()
    {
        isLocked = false;
        _audioSource.PlayOneShot(unlockDoorAudioClip);
    }
}