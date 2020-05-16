using UnityEngine;
using System.Collections;

public class ItemPickupInteractable : InteractableBase
{
    public string keyIdentifier;

    private Inventory _inventory;

    public override void Interact()
    {
        var item = new InventoryItem(keyIdentifier);
        _inventory.addItem(item, keyIdentifier);
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
