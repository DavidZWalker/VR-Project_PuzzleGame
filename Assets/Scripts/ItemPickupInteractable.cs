using UnityEngine;
using System.Collections;

public class ItemPickupInteractable : InteractableBase
{
    public string keyIdentifier;

    public override void Interact()
    {
        var inventory = Inventory.Instance;
        var item = new InventoryItem(keyIdentifier);
        inventory.addItem(item, keyIdentifier);
        Destroy(gameObject);

    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
