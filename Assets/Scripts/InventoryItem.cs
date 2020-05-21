public class InventoryItem
{
    public string ID
    {
        get;
        private set;
    }

    public bool IsPersistent
    {
        get;
        private set;
    }

    public InventoryItem(string keyIdentifier, bool isPersistent)
    {
        ID = keyIdentifier;
        IsPersistent = isPersistent;
    }
}