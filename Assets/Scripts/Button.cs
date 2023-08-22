using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
   public void NextBtn()
    {
        GameManager.Instance.CharacterList.GetComponent<CharacterList>().NextCharacterSelect();
    }
    public void PrevBtn()
    {
        GameManager.Instance.CharacterList.GetComponent<CharacterList>().PrevCharacterSelect();
    }

    public void StartBtn()
    {
        GameManager.Instance.GameStart();
        Camera.main.transform.position = new Vector3(0, 0, -10);
    }

    public void JumpBtn()
    {
        GameManager.Instance.SpringBoard.GetComponent<SpringBoard>().JumpCharacter();
    }
}
