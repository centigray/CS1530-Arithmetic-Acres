// ShopSlot.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemPrice;
    public Button buyButton;

    private ShopItem item;
    private ShopManager shopManager;

    public void Setup(ShopItem shopItem, ShopManager manager)
    {
        item = shopItem;
        shopManager = manager;

        itemIcon.sprite = shopItem.icon;
        itemName.text = shopItem.itemName;
        itemPrice.text = $"{shopItem.price} Gold";

        buyButton.onClick.AddListener(OnBuyClicked);
    }

    void OnBuyClicked()
    {
        shopManager.TryPurchase(item);
    }
}
