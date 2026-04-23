// ShopController.cs
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject shopPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // press B to toggle
            ToggleShop();
    }

    public void ToggleShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
}
