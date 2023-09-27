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
    [SerializeField] Animator animator;

    public BuildingType buildingType;
    public int level;
    public string buildingName;
    public string desc;
    public int upgradeWood;



    // ������ �ҷ�����
    public virtual void Initialization() 
    {
        buildingType = baseData.buildingType;
        level = baseData.level;
        buildingName = baseData.name;
        desc = baseData.desc;
        upgradeWood = baseData.upgradeWood;
    }

    public virtual void LevelUP()
    {
        level++;
        upgradeWood *= 2;
    }

    

    public void ActiveAnimation(bool isActive)
    {
        animator.enabled = isActive;
    }

    public void OnMouseDown()
    {
        BuildingController.instance.ActiveClickBuildingUI(this);
    }
}
