using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Health
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "New Item/ConsumableItem/Default")]
public class ConsumableItemData : ItemData
{
    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
