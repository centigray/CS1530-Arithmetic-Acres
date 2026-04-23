// ShopItem.cs
[System.Serializable]
public class ShopItem
{
    public string itemName;
    public string description;
    public int price;
    public UnityEngine.Sprite icon;
    public UnityEngine.GameObject prefab; // optional, if item spawns something
}
