using UnityEngine;
using UnityEngine.AI;

public class MarketBuilding : BaseBuilding
{
    public GameObject temp;
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


    private void Update()
    {
        float A = Random.Range(0f, 0.5f);
        float B = Random.Range(A, 0.5f);
        float C = Random.Range(0, 2);

        if (C == 1)
        {
            B = 1-B;
        }

        Vector2 AB = new Vector2(B, 10.5f);

        GameObject dot = Instantiate(temp);
        dot.transform.position = AB;
    }

    public void CheakTodayPrice()
    {

    }

    public void BuyResource()
    {

    }

}
