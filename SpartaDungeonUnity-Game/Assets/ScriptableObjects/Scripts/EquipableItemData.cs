using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipableType
{
    ATK,
    DEF,
    HP,
    CTK
}

[System.Serializable]
public class ItemDataEquipable
{
    public EquipableType type;
    public float value;
}

[CreateAssetMenu(fileName = "EquipableItem", menuName = "New Item/EquipableItem/Default")]
public class EquipableItemData : ItemData
{
    public bool isEquip;

    [Header("Equipable")]
    public ItemDataEquipable[] equipables;
}
