using UnityEngine;
using System.Collections;

public class ItemPickupInteractable : InteractableBase
{
    public string keyIdentifier;
    public bool isPersistent;
    public AudioClip pickUpAudioClip;

    private Inventory _inventory;

    public override void Interact()
    {
        var item = new InventoryItem(keyIdentifier, isPersistent);
        _inventory.AddItem(item);
        AudioSource.PlayClipAtPoint(pickUpAudioClip, transform.position);
        Destroy(gameObject);
    }

    public override void InternalStart()
    {
        _inventory = Inventory.Instance;
    }

    public override void InternalUpdate()
    {
        
    }
}
