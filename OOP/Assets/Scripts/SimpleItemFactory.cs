using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItemFactory : IItemFactory
{
    public Item CreateItem(string itemName)
    {
        return new Item(itemName);
    }
}
