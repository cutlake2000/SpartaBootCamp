using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public Image iconBackground;
    private ItemSlot curSlot;
    public GameObject equipMark;

    public int index;
    public bool equipped;

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        iconBackground.gameObject.SetActive(true);
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if (equipMark.activeInHierarchy != false)
        {
            equipMark.SetActive(equipped);
        }
    }

    public void Equip()
    {
        equipped = true;

        equipMark.SetActive(equipped);
    }

    public void Unequip()
    {
        equipped = false;

        equipMark.SetActive(equipped);
    }

    public void Clear()
    {
        curSlot = null;
        iconBackground.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        PlayerInventory.Instance.SelectItem(index);
    }
}
