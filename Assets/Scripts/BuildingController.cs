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
        // �׽�Ʈ��
        DeliverNewBuilding(BuildingType.Inn);
        DeliverNewBuilding(BuildingType.Forge);
        //

        DeliverNewBuilding(BuildingType.Inn);

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



    // '��Ȱ��ȭ'�� ���� ������ �ʱ�ȭ
    private void ResetBuildingData(BaseBuilding newBuilding)
    {
        newBuilding.Initialization();
        newBuilding.gameObject.SetActive(true);
    }


    // ���� UI
    public void ActiveBuildingUI()
    {
        // ���� �ٲ�� �ڵ����� ����(�̺�Ʈ ���)
        // ���� ������ UI ������
    }


}
