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
    public TextMeshProUGUI matchTryCountText; // 카드 뒤집은 횟수를 Canvas에 보여줄 TMPro
    public GameObject endText;
    public GameObject notificationText;
    public GameObject card;

    float time = 0f;

    public int matchTryCount; // 카드 뒤집은 횟수를 저장할 변수

    private void Awake()
    {
        Time.timeScale = 1.0f;
        gameManager = this;
    }

    void Start()
    {
        int[] cardNum = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        cardNum = cardNum.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        matchTryCount = 0; // matchCount 초기화

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.name = card.name + " " + i.ToString();
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            newCard.transform.position = new Vector3(x, y, 0);
            newCard.GetComponent<Card>().cardnum = cardNum[i];
            string imageName = "ourpic" + cardNum[i].ToString();
            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite =
                Resources.Load<Sprite>("Images/ourPictures/" + imageName);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
        matchTryCountText.text = "Count : " + matchTryCount.ToString();
    }

    public void isMatched()
    {
        // 카드가 매칭될 때마다 matchCount++;
        matchTryCount++;

        string firstCardImage = firstCard.transform
            .Find("Front")
            .GetComponent<SpriteRenderer>()
            .sprite.name;

        string secondCardImage = secondCard.transform
            .Find("Front")
            .GetComponent<SpriteRenderer>()
            .sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;

            if (cardsLeft == 2)
            {
                Invoke("GameEnd", 1f);
            }
            else
            {
                if (firstCardImage == "ourpic0" || firstCardImage == "ourpic1")
                {
                    notificationText.SetActive(true);
                    notificationText.GetComponent<TextMeshProUGUI>().text = "배인호";
                }
                else if (firstCardImage == "ourpic2" || firstCardImage == "ourpic3")
                {
                    notificationText.SetActive(true);
                    notificationText.GetComponent<TextMeshProUGUI>().text = "이경민";
                }
                else if (firstCardImage == "ourpic4" || firstCardImage == "ourpic5")
                {
                    notificationText.SetActive(true);
                    notificationText.GetComponent<TextMeshProUGUI>().text = "장성민";
                }
                else if (firstCardImage == "ourpic6" || firstCardImage == "ourpic7")
                {
                    notificationText.SetActive(true);
                    notificationText.GetComponent<TextMeshProUGUI>().text = "염종인";
                }
            }
        }
        else
        {
            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();
            notificationText.SetActive(true);
            notificationText.GetComponent<TextMeshProUGUI>().text = "실패!";
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
