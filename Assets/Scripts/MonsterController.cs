using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum MonsterType {Normal,Power,Speed }
public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private List<MonsterData> monsterDatas;
    [SerializeField]
    private GameObject Spawnner;
    [SerializeField]
    private GameObject MonsterPrefab;
    [SerializeField]
    private TextMeshProUGUI TxtMonsterCount;


    private int previousChildCount = -1; //���� �������� �ڽ� ������Ʈ ����
    private int CurMonsterCount;

    [Header("level")]
    public int MonsterCount = 10;  
    public int Level = 1;
    void Start()
    {
      
        StartCoroutine(SpawnMonsters()) ;    
    }
    void Update()
    {
        ChangeCountText();
    }






      private void ChangeCountText()// ���� �����Ӱ� ���� �������� �ڽ� ������Ʈ ������ �� �Ͽ� �ٲ�������� �ؽ�Ʈ�ٲ��� 
    {
        int currentChildCount = Spawnner.transform.childCount;


        if (currentChildCount != previousChildCount) 
        {

            TxtMonsterCount.text = currentChildCount.ToString();


            previousChildCount = currentChildCount;
        }
    }


         private Monster SpwanMonster(MonsterType type)
      {

        var newMonster = Instantiate(MonsterPrefab).GetComponent<Monster>();
        newMonster.transform.SetParent(Spawnner.transform);
        newMonster.monsterData = monsterDatas[(int)type];
        newMonster.name = newMonster.monsterData.MonsterName;    
        
        return newMonster;
    }
    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < MonsterCount; i++)
        {
            SetPosition();
            SpwanMonster((MonsterType)Level);         
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void SetPosition()
    {
        Vector3 newPosition = Spawnner.transform.position;
        MonsterPrefab.transform.position = newPosition;
    }

}
