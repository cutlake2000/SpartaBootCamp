using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MonsterController// : TopDownCharacterController
{
    public List<MonsterPattern> _pattern = new List<MonsterPattern>();
    public void Pattern()
    {

    }

    /// <summary>
    /// ���� ��ġ���� ������ �������� �̵�
    /// </summary>
    public void Move()
    {

    }

    /// <summary>
    /// ���� ��ġ���� Bullet�� ������ �������� �߻�.
    /// </summary>
    public void Fire()
    {
        GameObject bulletModel = DataManager.Instance.Bullet;

    }

    /// <summary>
    /// ���� ��ġ���� ������ ������ �ٶ�.
    /// </summary>
    public void Look()
    {

    }
}
public enum ePatternType
{
    Move,
    Aim,
    Fire,
    Look
}