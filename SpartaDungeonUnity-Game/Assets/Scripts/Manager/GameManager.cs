using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public GameObject player;

    public ItemData[] testItems;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < testItems.Length; i++)
        {
            player.GetComponent<PlayerInventory>().AddItem(testItems[i]);
        }
    }
}
