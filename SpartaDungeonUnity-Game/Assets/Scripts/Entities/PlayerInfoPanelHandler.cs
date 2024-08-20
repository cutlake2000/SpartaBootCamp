using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.IO.LowLevel.Unsafe;

public class PlayerInfoPanelHandler : PlayerPanelController
{
    [SerializeField]
    private TextMeshProUGUI playerLv;

    [SerializeField]
    private TextMeshProUGUI playerExp;

    [SerializeField]
    private TextMeshProUGUI playerGold;

    [SerializeField]
    private RectTransform expBar;

    private void Awake()
    {
        playerLv = playerLv.GetComponent<TextMeshProUGUI>();
        playerExp = playerExp.GetComponent<TextMeshProUGUI>();
        playerGold = playerGold.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        playerStatSO = UIManager.Instance.playerStatSO;

        WritePlayerLv(playerStatSO.lvValue);
        WritePlayerExp(playerStatSO.expValue, playerStatSO.maxExpValue);
        DrawPlayerExp(playerStatSO.expValue, playerStatSO.maxExpValue);
        WritePlayerGold(playerStatSO.gold);
    }

    private void WritePlayerLv(int lv)
    {
        playerLv.text = lv.ToString();
    }

    private void WritePlayerGold(int gold)
    {
        playerGold.text = gold + " G";
    }

    private void WritePlayerExp(float exp, float maxExp)
    {
        playerExp.text = exp + " / " + maxExp;
    }

    private void DrawPlayerExp(float exp, float maxExp)
    {
        expBar = expBar.GetComponent<RectTransform>();

        expBar.sizeDelta = new Vector2(exp / maxExp * 400, expBar.sizeDelta.y);
    }
}
