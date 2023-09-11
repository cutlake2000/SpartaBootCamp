using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MonsterController// : TopDownCharacterController
{
    public MonsterPattern Pattern { get; set; } = new MonsterPattern();
    private Pattern[] _currentPattern = null;
    private int _index = 0;
    private float _time = 0;
    public void PatternLoop()
    {
        _time += Time.deltaTime;
        if (_currentPattern == null || _index >= _currentPattern.Length)
        {
            _currentPattern = Pattern.GetPattern(_index);
            _index = 0;
        }
        if (_currentPattern != null)
        {
            
            switch(_currentPattern[_index].Type)
            {
                case ePatternType.None:
                    break;
                case ePatternType.Move:
                    break;
                case ePatternType.Fire:
                    break;
                case ePatternType.Look:
                    break;
            }
        }
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
