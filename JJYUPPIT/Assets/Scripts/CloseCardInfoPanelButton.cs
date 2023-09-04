using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCardInfoPanelButton : MonoBehaviour
{
    public void CloseCardInfoPanel()
    {
        transform.parent.gameObject.SetActive(false);
        GameManager.gameManager.PauseTime(false);
    }
}
