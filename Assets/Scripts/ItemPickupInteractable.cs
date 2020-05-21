using UnityEngine;
using System.Collections;

public class ItemPickupInteractable : InteractableBase
{
    public string keyIdentifier;
    public bool isPersistent;

    private Inventory _inventory;

    public override void Interact()
    {
        var item = new InventoryItem(keyIdentifier, isPersistent);
        _inventory.AddItem(item);
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
