using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    private GameObject player;

    [SerializeField]
    private GameObject playerPanel;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject buttonPanel;

    [SerializeField]
    public GameObject statusPanel;

    [SerializeField]
    public GameObject inventoryPanel;

    [SerializeField]
    public GameObject confirmPanel;

    [SerializeField]
    public GameObject itemEquipConfirmPanel;

    [SerializeField]
    public TextMeshProUGUI menuText;

    public PlayerStatSO playerStatSO;

    private ItemSlot selectedItem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Init();
    }

    private void Init()
    {
        player = GameManager.Instance.player;
        playerStatSO = player.GetComponent<CharacterStatsHandler>().currentStats.playerStatSO;
        menuText = menuText.GetComponent<TextMeshProUGUI>();
    }

    public void TurnOnStatusPanel()
    {
        buttonPanel.SetActive(false);

        SetMenuText(Menu.Status);
        statusPanel.SetActive(true);
    }

    public void TurnOffStatusPanel()
    {
        statusPanel.SetActive(false);

        SetMenuText(Menu.Menu);
        buttonPanel.SetActive(true);
    }

    public void TurnOnInventoryPanel()
    {
        buttonPanel.SetActive(false);

        SetMenuText(Menu.Inventory);
        inventoryPanel.SetActive(true);
    }

    public void TurnOffInventoryPanel()
    {
        inventoryPanel.SetActive(false);

        SetMenuText(Menu.Menu);
        buttonPanel.SetActive(true);
    }

    public void TurnOnItemEquipConfirmPanel(ItemSlot selectedItem)
    {
        this.selectedItem = selectedItem;

        confirmPanel.SetActive(true);
        itemEquipConfirmPanel.SetActive(true);
    }

    public void TurnOffItemEquipConfirmPanel()
    {
        confirmPanel.SetActive(false);
        itemEquipConfirmPanel.SetActive(false);

        PlayerInventory.Instance.EquipItem();
    }

    public void EquipConfirm() { }

    private void SetMenuText(Menu menu)
    {
        switch (menu)
        {
            case Menu.Menu:
                menuText.text = "메뉴";
                break;
            case Menu.Status:
                menuText.text = "상태창";
                break;
            case Menu.Inventory:
                menuText.text = "인벤토리";
                break;
            case Menu.Shop:
                menuText.text = "상점";
                break;
        }
    }

    private enum Menu
    {
        Menu,
        Status,
        Inventory,
        Shop
    }
}
