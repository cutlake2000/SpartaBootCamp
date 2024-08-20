using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatusPanelHandler : PlayerPanelController
{
    [SerializeField]
    private TextMeshProUGUI playerAtk;

    [SerializeField]
    private TextMeshProUGUI playerDef;

    [SerializeField]
    private TextMeshProUGUI playerHp;

    [SerializeField]
    private TextMeshProUGUI playerCtk;

    private void Awake()
    {
        playerAtk = playerAtk.GetComponent<TextMeshProUGUI>();
        playerDef = playerDef.GetComponent<TextMeshProUGUI>();
        playerHp = playerHp.GetComponent<TextMeshProUGUI>();
        playerCtk = playerCtk.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        playerStatSO = UIManager.Instance.playerStatSO;

        WritePlayerAtk(playerStatSO.atkValue);
        WritePlayerDef(playerStatSO.defValue);
        WritePlayerHp(playerStatSO.hpValue);
        WritePlayerCtk(playerStatSO.ctkValue);
    }

    private void WritePlayerAtk(float atk)
    {
        playerAtk.text = atk.ToString();
    }

    private void WritePlayerDef(float def)
    {
        playerDef.text = def.ToString();
    }

    private void WritePlayerHp(float hp)
    {
        playerHp.text = hp.ToString();
    }

    private void WritePlayerCtk(float ctk)
    {
        playerCtk.text = ctk.ToString();
    }
}
