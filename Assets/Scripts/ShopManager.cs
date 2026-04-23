// ShopManager.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] items;
    public Transform itemContainer;   // parent object for UI buttons
    public GameObject shopItemPrefab; // UI prefab for each item slot
    public TextMeshProUGUI currencyText;

    private int playerCurrency = 100;

    void Start()
    {
        UpdateCurrencyUI();
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (ShopItem item in items)
        {
            GameObject slot = Instantiate(shopItemPrefab, itemContainer);
            ShopSlot shopSlot = slot.GetComponent<ShopSlot>();
            shopSlot.Setup(item, this);
        }
    }

    public bool TryPurchase(ShopItem item)
    {
        if (playerCurrency >= item.price)
        {
            playerCurrency -= item.price;
            UpdateCurrencyUI();
            Debug.Log($"Purchased: {item.itemName}");
            // Add to inventory here
            return true;
        }
        else
        {
            Debug.Log("Not enough currency!");
            return false;
        }
    }

    void UpdateCurrencyUI()
    {
        if (currencyText != null)
            currencyText.text = $"Gold: {playerCurrency}";
    }
}
