using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingType
{
    Inn, Forge
}

public class BuildingController : MonoBehaviour
{
    public static BuildingController instance;

    [SerializeField] BuildingSO buildingSO;
    [SerializeField] GameObject[] BuildingPrefabs;
    public List<BaseBuilding> buildings;

    private void Awake()
    {
        instance = this;
        buildings = new List<BaseBuilding>();

    }

    public void Start()
    {
        // - �׽�Ʈ��
        DeliverNewBuilding(BuildingType.Inn);
        DeliverNewBuilding(BuildingType.Forge);
        //
    }

    // ���� �߰��� �ش� ��ġ�� �̵�
    public void SetNewBuildingOnMap(BuildingType type, Vector3 pos)
    {
        BaseBuilding newBuilding = DeliverNewBuilding(type);
        newBuilding.transform.position = pos;
    }

    // ���� ������Ʈ�� ���� ����
    private BaseBuilding DeliverNewBuilding(BuildingType type)
    {
        BaseBuilding newBuilding;
        for (int i = 0; i < buildings.Count; i++)
        {
            if (buildings[i].buildingType != type)
                continue;
            if (buildings[i].gameObject.activeSelf == false)
                continue;

            newBuilding = buildings[i];
            ResetBuildingData(newBuilding);
            return newBuilding;
        }

        newBuilding = Instantiate(BuildingPrefabs[(int)type]).GetComponent<BaseBuilding>();
        newBuilding.name = type.ToString();
        newBuilding.baseData = buildingSO.buildingDatas[(int)type];
        newBuilding.Initialization();
        buildings.Add(newBuilding);
        return newBuilding;
    }

    public void UpgradeBuilding(BaseBuilding tagetBuilding)
    {
        if (tagetBuilding.upgradeGold >= DataManager.instance.player.Gold)
        {
            // + ���� ó��
        }

        DataManager.instance.player.Gold -= tagetBuilding.upgradeGold;
        tagetBuilding.LevelUP();
        // + ���� ó��
    }


    // '��Ȱ��ȭ'�� ���� ������ �ʱ�ȭ
    private void ResetBuildingData(BaseBuilding newBuilding)
    {
        newBuilding.Initialization();
        newBuilding.gameObject.SetActive(true);
    }


    // ���� UI
    public void ActiveBuildingUI()
    {
        // + ���� �ٲ�� �ڵ����� ������
        // + ���� ������ UI ������
    }


    // ���� ȿ�� ����
    public void RefreshInnEffect()
    {
        int sum = 0;
        for (int i = 0; i < buildings.Count; i++)
        {
            if (buildings[i].buildingType != BuildingType.Inn)
                continue;
            if (buildings[i].gameObject.activeSelf == false)
                continue;

            InnBuilding building = (InnBuilding)buildings[i];
            sum += building.MaxUnitValue;
        }

        DataManager.instance.player.MaxUnitCount = sum;
        Debug.Log("���尣 ȿ�� : " + DataManager.instance.player.MaxUnitCount);
        // ++ UI ����
    }

    // ���尣 ȿ�� ����
    public void RefreshForgeEffect()
    {
        int sum = 0;
        for (int i = 0; i < buildings.Count; i++)
        {
            if (buildings[i].buildingType != BuildingType.Forge)
                continue;
            if (buildings[i].gameObject.activeSelf == false)
                continue;

            ForgeBuilding building = (ForgeBuilding)buildings[i];
            sum += building.AddUnitAtk;
        }

        DataManager.instance.player.AddUnitAtk = sum;
        Debug.Log("���尭 ȿ�� : " + DataManager.instance.player.MaxUnitCount);

        // ++ UI ����
    }


}
