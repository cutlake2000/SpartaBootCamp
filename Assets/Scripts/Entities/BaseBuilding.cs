using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    public BuildingData baseData;
    
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    public BuildingType buildingType;
    public List<ClickBtnType> DefaultOptionType;
    public int level;
    public int maxLevel;
    public string buildingName;
    public string desc;

    public int maxBuildLimit;
    public int buildWood;
    public int upgradeWood;

    // 초기화
    public virtual void Initialization()
    {
        buildingType = baseData.buildingType;
        level = baseData.level;
        maxLevel = baseData.maxLevel;
        buildingName = baseData.name;
        desc = baseData.desc;
        upgradeWood = baseData.upgradeWood;
        DefaultOptionType = baseData.optionTypeList;

        maxBuildLimit = baseData.maxBuildLimit;
        buildWood = baseData.buildWood;
    }

    public virtual void LevelUP()
    {
        // TODO 최대 레벨 지정하고 달성시
        // 클릭 UI 색으로 비활성화 나타내기
        level++;
        upgradeWood *= 2;
    }

    

    public void ActiveAnimation(bool isActive)
    {
        animator.enabled = isActive;
    }

    public void OnMouseDown()
    {
        BuildingController.Instance.ActiveClickBuildingUI(this);
    }

}
