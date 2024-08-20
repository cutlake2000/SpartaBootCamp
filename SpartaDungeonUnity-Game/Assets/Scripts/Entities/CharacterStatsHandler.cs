using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterStats baseStats;

    public CharacterStats currentStats { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        PlayerStatSO playerStatSO = null;

        if (baseStats.playerStatSO != null)
        {
            playerStatSO = Instantiate(baseStats.playerStatSO);
        }

        currentStats = new CharacterStats { playerStatSO = playerStatSO };

        // TODO
        // currentStats.statsChangeType = baseStats.statsChangeType;
    }
}
