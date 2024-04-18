using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_InputField addItemInputField; // Reference to a TMP_InputField for adding items
    public TMP_InputField deleteItemInputField; // Reference to a TMP_InputField for deleting items
    private InventoryWithObserver inventory;

    private void Start()
    {
        inventory = GameObject.FindObjectOfType<InventoryWithObserver>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Check for the Enter key (Return key on some keyboards)
        {
            string itemName = addItemInputField.text.Trim(); // Get the typed item name and remove any leading or trailing spaces
            if (!string.IsNullOrEmpty(itemName))
            {
                inventory.AddItem(itemName);
                addItemInputField.text = ""; // Clear the input field after adding the item
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) // Check for the Enter key (Return key on some keyboards)
        {
            string itemName = deleteItemInputField.text.Trim(); // Get the typed item name and remove any leading or trailing spaces
            if (!string.IsNullOrEmpty(itemName))
            {
                inventory.RemoveItem(itemName);
                deleteItemInputField.text = ""; // Clear the input field after deleting the item
            }
        }
    }
}
