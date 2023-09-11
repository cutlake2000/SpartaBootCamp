using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MonsterController : TopDownCharacterController
{
    public MonsterPattern Pattern { get; set; } = new MonsterPattern();
    private Pattern[] _currentPattern = null;
    private int _index = 0;
    private void PatternUpdate()
    {
        int endCount = 0;
        foreach (var pattern in _currentPattern)
        {
            if (pattern.IsEnd())
            {
                ++endCount;
                continue;
            }
            else
            {
                pattern.Loop();
                switch (pattern.Type)
                {
                    case ePatternType.None:
                        break;
                    case ePatternType.Move:
                        Move(pattern);
                        break;
                    case ePatternType.Fire:
                        Fire(pattern);
                        break;
                    case ePatternType.Look:
                        Look(pattern);
                        break;
                    default:
                        break;
                }
            }
        }
        if (_currentPattern == null || endCount >= _currentPattern.Length)
        {
            _currentPattern = Pattern.GetPattern(_index++);
        }
    }

    protected override void Update()
    {
        base.Update();
        PatternUpdate();
    }

    /// <summary>
    /// ���� ��ġ���� ������ �������� �̵�
    /// </summary>
    private void Move(Pattern pattern)
    {
        var currentPos = this.gameObject.transform.position;
        Vector2 targetPos = (Vector2)currentPos + pattern.Direction;
        CallMoveEvent(targetPos);
    }

    /// <summary>
    /// ���� ��ġ���� Bullet�� ������ �������� �߻�.
    /// </summary>
    private void Fire(Pattern pattern)
    {
        if (pattern.IsNeedRun())
            CallFireEvent(pattern.Direction);
    }

    /// <summary>
    /// ���� ��ġ ���ؿ��� ������ ������ �ٶ�.
    /// </summary>
    private void Look(Pattern pattern)
    {
        var currentPos = this.gameObject.transform.position;
        Vector2 targetPos = (Vector2)currentPos + pattern.Direction;
        CallLookEvent(targetPos);
    }
}
