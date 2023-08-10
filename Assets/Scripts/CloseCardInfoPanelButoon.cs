using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCardInfoPanelButoon : MonoBehaviour
{
    public void CloseCardInfoPanel()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
