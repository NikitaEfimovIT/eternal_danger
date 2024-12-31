using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem
{
    public float itemId;
    public int doorId;

    public KeyItem(float itemId, int doorId)
    {
        this.itemId = itemId;
        this.doorId = doorId;
    }
    
    
}

public class Inventory
{
    private List<KeyItem> items;

    public Inventory()
    {
        this.items = new List<KeyItem>();
    }
    
    public void AddItem(KeyItem item)
    {
        this.items.Add(item);
        Debug.Log(item.itemId);
    }

    public KeyItem FindItem(int doorId)
    {
        KeyItem keyItem = this.items.Find(item => item.doorId == doorId);
        return keyItem;
    }

    public List<KeyItem> GetItems()
    {
        return this.items;
    }
}
