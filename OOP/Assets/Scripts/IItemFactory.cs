using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemFactory
{
    Item CreateItem(string itemName);
}

