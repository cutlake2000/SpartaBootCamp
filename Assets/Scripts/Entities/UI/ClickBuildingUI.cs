using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickBuildingUI : MonoBehaviour
{
    enum BtnOptionType { MaxLvUp, LvUp, Destroy, Back, Buy, Sell }
    enum InfoTextType { Name, CurrentEffect, Upgrade }

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

    // 정보 갱신
    public void Refresh(BaseBuilding target)
    {

        newStatusText.Clear();
        newStatusText.Append($"Lv. {target.level} {target.buildingName}");
        texts[(int)InfoTextType.Name].text = newStatusText.ToString();

        newStatusText.Clear();
        switch (target.buildingType)
        {
            case BuildingType.Inn:
                newStatusText.Append($"인구 수 증가 : {((InnBuilding)target).MaxUnitValue}");
                break;
            case BuildingType.Forge:
                newStatusText.Append($"공격력 증가 : {((ForgeBuilding)target).AddUnitAtk}");
                break;
            case BuildingType.Market:
                MarketBuilding market = (MarketBuilding)target;
                int price = (int)(market.CurrentPrice * 100);
                newStatusText.Append($"현재 시세 :{price}");
                break;
            default:
                break;
        }
        texts[(int)InfoTextType.CurrentEffect].text = newStatusText.ToString();

        newStatusText.Clear();
        newStatusText.Append($"{target.upgradeWood}");
        texts[(int)InfoTextType.Upgrade].text = newStatusText.ToString();
    }

    // 아이콘 레이캐스트 스위치
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
