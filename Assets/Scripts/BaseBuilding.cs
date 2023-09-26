using UnityEngine;


// �ǹ� ���� -> ��Ʈ�ѷ�
// ���׷��̵� ������
// Inn : ���� �� ����
// Forge : ���� ���׷��̵�


public enum BuildingType
{
    Inn, Forge
}

public class BaseBuilding : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public BuildingType buildingType;
    public int level;
    public string buildingName;
    public string desc;
    public int upgradeGold;


    //�ǹ� ����,
    protected virtual void Awake() { }

    protected virtual void Initialization(BuildingData data) { }

    protected virtual void UpgradeBuilding()
    {

    }

    void Start()
    {
        
    }


}
