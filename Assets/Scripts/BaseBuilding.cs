using UnityEngine;


// �ǹ� ���� -> ��Ʈ�ѷ�
// ���׷��̵� ������
// Inn : ���� �� ����
// Forge : ���� ���׷��̵�
//



public class BaseBuilding : MonoBehaviour
{
    public BuildingData baseData;
    
    [SerializeField] SpriteRenderer spriteRenderer;

    public BuildingType buildingType;
    public int level;
    public string buildingName;
    public string desc;
    public int upgradeGold;



    // ������ �ҷ�����
    public virtual void Initialization() 
    {
        buildingType = baseData.buildingType;
        level = baseData.level;
        buildingName = baseData.name;
        desc = baseData.desc;
        upgradeGold = baseData.upgradeGold;
    }

    protected virtual void UpgradeBuilding()
    {

    }
}
