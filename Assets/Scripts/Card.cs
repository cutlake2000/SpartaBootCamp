using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Animator cardAnim;
    public int cardnum;

    public AudioSource cardSource;
    public AudioClip flipSound;

    public GameObject front;
    public GameObject back;

    public void OpenCard()
    {
        cardSource.PlayOneShot(flipSound);

        //cardAnim.SetBool("isOpen", true);
        cardAnim.SetBool("isReverse", true);
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
        cardAnim.SetBool("isSet", true);
        
        Invoke("CloseCardInvoke", 0.5f);
    }

    public void CloseCardInvoke()
    {
        //cardAnim.SetBool("isOpen", false);
        

        //transform.Find("Back").gameObject.SetActive(true);
        //transform.Find("Front").gameObject.SetActive(false);
        transform.Find("Back").gameObject.GetComponent<SpriteRenderer>().color = new Color(
            150f / 255f,
            150f / 255f,
            150f / 255f,
            1
        );
    }

    public void CardReverse()
    {
        front.SetActive(true);
        back.SetActive(false);
    }    

    public void RevereseEnd()
    {
        cardAnim.SetBool("isReverse", false);
    }

    public void SetEnd()
    {
        cardAnim.SetBool("isSet", false);
    }

    public void CardSet()
    {
        front.SetActive(false);
        back.SetActive(true);
    }
}
