using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory_UI : MonoBehaviour
{ 
    public Player player;
    public List<SlotsUI> slots = new List<SlotsUI>();

    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        //if(slots.Count == player.inventory.slots.Count)
        //{
            for(int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        //}
    }

    public void Remove(int slotID)
    {
        player.inventory.Remove(slotID);
        Refresh();
    }

    // when the player clicks on an inventory slot, it is selected
    public void Select(int slotID)
    {
        slots[player.inventory.selectedIndex].DeselectItem();
        player.inventory.Select(slotID);
        slots[slotID].SelectItem();
    }
}
