public class InventoryItem
{
    private string _keyIdentifier;

    public InventoryItem(string keyIdentifier)
    {
        _keyIdentifier = keyIdentifier;
        var door = new DoorInteractable();
    }
}