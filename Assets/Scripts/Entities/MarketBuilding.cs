using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.Diagnostics;

public class MarketBuilding : BaseBuilding
{
    float price = 1.0f; // ���� �ü�

    float currentPrice; // ���� �ü�
    float minPrice = 0.2f; // �ּ� �ü�
    float maxPrice = 3.0f; // �ִ� �ü�
    // 1.0�� �������� ���ϸ� ����?? �������� �� �����

    float buyItem = 1.1f;
    float sellItem = 0.9f;
    // �춧 �ȶ� = 110% 90%?

    int goldToWood = 10; 
    // ��� -> ���� ��ȯ��


    public float CurrentPrice { get { return currentPrice; } }

    public override void Initialization()
    {
        base.Initialization();
        price = 1.0f;
    }

    public void CheakTodayPrice()
    {
    }

    public void BuyResource()
    {

    }


}
