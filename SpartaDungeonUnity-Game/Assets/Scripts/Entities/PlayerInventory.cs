using System;
using UnityEngine;

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}

public class PlayerInventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;

    public static PlayerInventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        slots = new ItemSlot[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }

        ClearSeletecItemWindow();
    }

    public void AddItem(ItemData item)
    {
        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = item;
            UpdateUI();
            return;
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item)
                return slots[i];
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }

        return null;
    }

    public void EquipItem()
    {
        uiSlots[selectedItemIndex].Equip();
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        // switch (selectedItem.item.type)
        // {
        //     case ItemType.Equipable:
        //         if (selectedItem.item. = true)
        //         {
        //             UIManager.Instance.TurnOnItemEquipConfirmPanel(selectedItem);
        //         }

        //         break;
        //     case ItemType.Consumable:
        //         break;
        // }
    }

    private void ClearSeletecItemWindow()
    {
        selectedItem = null;
    }
}
