using System;
using System.Collections.Generic;

/// <summary>
/// A singleton class for storing picked up items
/// </summary>
public class Inventory
{
    /// <summary>
    /// private variable for the inventory instance
    /// </summary>
    private static Inventory _instance;

    /// <summary>
    /// Dictionary to store the items in
    /// </summary>
    private IDictionary<string, InventoryItem> _items;

    /// <summary>
    /// Creates a new instance of the <see cref="Inventory"/> class
    /// </summary>
    private Inventory()
    {
        _items = new Dictionary<string, InventoryItem>();
    }

    /// <summary>
    /// Gets the current instance <see cref="Inventory"/>. If no instance exists, a new one is created and returned
    /// </summary>
    public static Inventory Instance
    {
        get
        {
            _instance = _instance == null ? new Inventory() : _instance;
            return _instance;
        }
    }

    /// <summary>
    /// Adds an item with the given key to the inventory
    /// </summary>
    /// <param name="item">the item to add</param>
    /// <param name="itemKey">the item's key identifier</param>
    public void addItem(InventoryItem item, string itemKey)
    {
        if (item != null)
        {
            _items.Add(itemKey, item);
        }
    }

    /// <summary>
    /// Removes an item with the given key from the inventory
    /// </summary>
    /// <param name="itemKey">the item's key identifier</param>
    public void removeItem(string itemKey)
    {
        if (!string.IsNullOrEmpty(itemKey))
        {
            _items.Remove(itemKey);
        }
    }
}
