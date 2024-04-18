using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryWithObserver : MonoBehaviour
{
    private Dictionary<string, int> inventoryItems = new Dictionary<string, int>();
    private TextMeshProUGUI inventoryText;
    private List<IInventoryObserver> observers = new List<IInventoryObserver>();

    private void Start()
    {
        inventoryText = GameObject.Find("InventoryText").GetComponent<TextMeshProUGUI>();
        UpdateInventoryUI();
    }

    public void AddObserver(IInventoryObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnInventoryChanged();
        }
    }

    public void AddItem(string itemName)
    {
        if (inventoryItems.ContainsKey(itemName))
        {
            inventoryItems[itemName]++;
        }
        else
        {
            inventoryItems.Add(itemName, 1);
        }

        NotifyObservers();
        UpdateInventoryUI(); // Update the UI after adding the item
    }

    public void RemoveItem(string itemName)
    {
        if (inventoryItems.ContainsKey(itemName))
        {
            if (inventoryItems[itemName] > 1)
            {
                inventoryItems[itemName]--;
            }
            else
            {
                inventoryItems.Remove(itemName);
            }

            NotifyObservers();
            UpdateInventoryUI(); // Update the UI after removing the item
        }
    }

    private void UpdateInventoryUI()
    {
        inventoryText.text = "Inventory:\n";

        foreach (KeyValuePair<string, int> item in inventoryItems)
        {
            inventoryText.text += $"{item.Key} x{item.Value}\n";
        }
    }
}
