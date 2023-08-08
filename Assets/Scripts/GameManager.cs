using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public GameObject firstCard;
    public GameObject secondCard;
    public TextMeshProUGUI timeText;
    public GameObject endText;
    public GameObject card;
    float time = 0f;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        gameManager = this;
    }

    void Start()
    {
        int[] cardNum = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        cardNum = cardNum.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i=0; i<16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.name = card.name + " " + i.ToString();
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            newCard.transform.position = new Vector3(x, y, 0);

            string imageName = "rtan" + cardNum[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/rtan/" + imageName);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite.name;

        if(firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            if(cardsLeft == 2)
            {
                Invoke("GameEnd", 1f);
            }
        }
        else
        {
            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    private void GameEnd()
    {
        Time.timeScale = 0f;
        endText.SetActive(true);
    }
}
