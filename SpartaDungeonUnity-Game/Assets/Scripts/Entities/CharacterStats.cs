using System;

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    public PlayerStatSO playerStatSO;
}

public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}
