using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Animator cardAnim;
    public int cardnum;

    public void OpenCard()
    {
        cardAnim.SetBool("isOpen", true);
        transform.Find("Front").gameObject.SetActive(true);
        transform.Find("Back").gameObject.SetActive(false);

        if (GameManager.gameManager.firstCard == null)
        {
            GameManager.gameManager.firstCard = gameObject;
        }
        else
        {
            GameManager.gameManager.secondCard = gameObject;
            GameManager.gameManager.isMatched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    private void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    private void CloseCardInvoke()
    {
        cardAnim.SetBool("isOpen", false);
        transform.Find("Back").gameObject.SetActive(true);
        transform.Find("Front").gameObject.SetActive(false);
        transform.Find("Back").gameObject.GetComponent<SpriteRenderer>().color = new Color(
            150f / 255f,
            150f / 255f,
            150f / 255f,
            1
        );
    }
}
