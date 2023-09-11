using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private BulletData bulletData;
    public BulletData BulletData { set { bulletData = value; } }
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    /// <summary>
    /// �߻��ϴ� ��ü�� �����̼� ���� �Ѱ��ָ� �˴ϴ�.
    /// </summary>
    /// <param name="quaternion"></param>
    public void Bang(Quaternion quaternion)
    {
        float z = quaternion.z;
        Vector2 front = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = front * bulletData.Speed;
    }
}
