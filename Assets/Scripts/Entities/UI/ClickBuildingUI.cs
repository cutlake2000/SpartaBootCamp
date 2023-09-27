using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ClickBuildingUI : MonoBehaviour
{
    enum ClickBuildUIText { Name, CurrentEffect, Upgrade }

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
        ActiveRaycastTargrt(false);
        gameObject.SetActive(false);
    }

    public void Refresh(BaseBuilding target)
    {

        newStatusText.Clear();
        newStatusText.Append($"Lv. {target.level} {target.buildingName}");
        texts[(int)ClickBuildUIText.Name].text = newStatusText.ToString();

        newStatusText.Clear();
        switch (target.buildingType)
        {
            case BuildingType.Inn:
                newStatusText.Append($"인구 수 증가 : {((InnBuilding)target).MaxUnitValue}");
                break;
            case BuildingType.Forge:
                newStatusText.Append($"공격력 증가 : {((ForgeBuilding)target).AddUnitAtk}");
                break;
            default:
                break;
        }
        texts[(int)ClickBuildUIText.CurrentEffect].text = newStatusText.ToString();

        newStatusText.Clear();
        newStatusText.Append($"{target.upgradeWood}");
        texts[(int)ClickBuildUIText.Upgrade].text = newStatusText.ToString();
    }
    // 아이콘 레이캐스트 스위치
    public void ActiveRaycastTargrt(bool isON)
    {
        foreach (var item in texts)
        {
            item.raycastTarget = true;
        }
    }


}
