using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHandler : UIManager
{
    [Header("Target")]
    [SerializeField]
    private GameObject playerPanel;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject buttonPanel;

    [SerializeField]
    private GameObject statusPanel;

    [SerializeField]
    private GameObject inventoryPanels;

    [SerializeField]
    private GameObject ConfirmPanel;

    private enum Menu
    {
        Menu,
        Status,
        Inventory,
        Shop
    }

    public void TurnOnStatusPanel()
    {
        SetMenuText(Menu.Status);
        buttonPanel.SetActive(false);
        statusPanel.SetActive(true);
    }

    public void TurnOffStatusPanel()
    {
        SetMenuText(Menu.Menu);
        buttonPanel.SetActive(true);
        statusPanel.SetActive(false);
    }

    public void TurnOnInventoryPanel()
    {
        SetMenuText(Menu.Inventory);
        buttonPanel.SetActive(false);
        inventoryPanels.SetActive(true);
    }

    public void TurnOffInventoryPanel()
    {
        SetMenuText(Menu.Menu);
        buttonPanel.SetActive(true);
        inventoryPanels.SetActive(false);
    }

    public void TurnOnEquipConfirmPanel() { }

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
}
