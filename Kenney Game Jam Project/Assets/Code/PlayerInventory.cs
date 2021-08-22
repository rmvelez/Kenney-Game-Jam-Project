using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int maxPerSlot = 10;
    List<InventorySlot> slots = new List<InventorySlot>();

    public bool Add(Item i)
    {
        var toAdd = new InventorySlot(i);

        int index = slots.FindIndex((slot) => slot.Name.Equals(toAdd.Name));
        
        if(index < 0)
        {
            slots.Add(toAdd);
        }
        else
        {
            if (IsSlotFull( slots[index] ))
                return false;

            slots[index] += toAdd;
        }

        return true;
    }

    bool IsSlotFull(InventorySlot s)
    {
        return s.count >= maxPerSlot;
    }

    public int GetCount(string itemName)
    {
        var targetSlot = slots.Find((slot) => slot.Name == itemName);

        if (!targetSlot.item)
            return 0;

        return targetSlot.count;
    }
}

public struct InventorySlot
{
    public readonly Item item;
    public readonly int count;
    public string Name => item.Name;

    public InventorySlot(Item i)
    {
        item = i;
        count = 1;
    }

    public InventorySlot(Item i, int c)
    {
        item = i;
        count = c;
    }

    public static InventorySlot operator +(InventorySlot a, InventorySlot b)
    {
        return new InventorySlot(a.item, a.count + b.count);
    }
}