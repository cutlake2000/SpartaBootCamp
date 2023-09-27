using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
   
    public MonsterData MonsterData;
    float MonsterHp;
    private void Start()
    {
        MonsterHp = MonsterData.MonsterHp;
    }


    public void TakePhysicalDamage(int damageAmount)
    {
        MonsterHp -= damageAmount;
        if (MonsterHp <= 0)
            Die();     
    }


    void Die()
    {
         //ToDo �ڿ� ŉ�� ��� 

        Destroy(gameObject);
}
    }
