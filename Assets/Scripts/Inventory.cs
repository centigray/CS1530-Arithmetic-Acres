using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections.Generic;
using System.Collections;
[System.Serializable]

public class Inventory
{
  [System.Serializable]
   public class Slot
    {
        // attributes of a slot
        public CollectableType type;
        public int count; // num of items in the slot
        public int maxAllowed; // max amt of items in the slot

        public Sprite icon;
        
        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 10;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;
                if (count == 0)
                {
                    this.type = CollectableType.NONE;
                    this.icon = null;
                }
            }
        }
    }
    // list of slots for items
    public List<Slot> slots = new List<Slot>();
    public int selectedIndex;

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
        selectedIndex = 0;
    }
    // let player add items to inventory when they pick them up
    public void Add(Collectable item)
    {
        //search inv for items that are same
        foreach(Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                // add item to inv
                slot.AddItem(item);
                return;
            }
        }
        //add item if we dont have it yet/ slot full
        foreach (Slot slot in slots)
        {
            // slot empty --> add item to slot
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    // this function removes an item! note that it is different from add and
    // you have to pass the index of the item you want to remove
    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

    public void Select(int index)
    {
        selectedIndex = index;
    }
}
