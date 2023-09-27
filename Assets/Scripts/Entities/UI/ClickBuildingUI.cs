using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickBuildingUI : MonoBehaviour
{
    enum ClickBuildUIText { Name, CurrentEffect, Upgrade }

    [SerializeField] Image[] buttons;
    [SerializeField] TMP_Text[] texts;
    private StringBuilder newStatusText = new();

    public void On(BaseBuilding building)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(building.transform.position);
        transform.position = screenPos;

        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }

    public void OFF()
    {
        DeactivateRaycastTargrt();
        gameObject.SetActive(false);
    }

    // ���� ����
    public void Refresh(BaseBuilding target)
    {

        newStatusText.Clear();
        newStatusText.Append($"Lv. {target.level} {target.buildingName}");
        texts[(int)ClickBuildUIText.Name].text = newStatusText.ToString();

        newStatusText.Clear();
        switch (target.buildingType)
        {
            case BuildingType.Inn:
                newStatusText.Append($"�α� �� ���� : {((InnBuilding)target).MaxUnitValue}");
                break;
            case BuildingType.Forge:
                newStatusText.Append($"���ݷ� ���� : {((ForgeBuilding)target).AddUnitAtk}");
                break;
            default:
                break;
        }
        texts[(int)ClickBuildUIText.CurrentEffect].text = newStatusText.ToString();

        newStatusText.Clear();
        newStatusText.Append($"{target.upgradeWood}");
        texts[(int)ClickBuildUIText.Upgrade].text = newStatusText.ToString();
    }

    // ������ ����ĳ��Ʈ ����ġ
    public void DeactivateRaycastTargrt()
    {
        foreach (var item in buttons)
        {
            item.raycastTarget = false;
        }
    }

    public void ActivateRaycastTargrt()
    {
        foreach (var item in buttons)
        {
            item.raycastTarget = true;
        }
    }

}
