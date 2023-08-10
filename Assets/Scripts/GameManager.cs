using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public TimeText timeTextAnimation;

    public GameObject firstCard;
    public GameObject secondCard;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI matchTryCountText; // 카드 뒤집은 횟수를 Canvas에 보여줄 TMPro
    public GameObject inGamePanel; // 게임 플레이 화면
    public GameObject notificationText; // 카드 정보 혹은 실패 문구 출력

    public GameObject resultPanel; // 게임 결과창
    public TextMeshProUGUI remainTimeText; // 남은 시간
    public TextMeshProUGUI tryCountText; // 카드 뒤집기 시도 횟수
    public TextMeshProUGUI scoreText; // 최종 점수
    public TextMeshProUGUI bestScoreText; // 최종 점수

    public GameObject card;
    public AudioSource managerSource;
    public AudioClip checkSound;

    private float timeLimit = 0.0f;
    float time = 30f;
    int score; // 게임 점수

    public int matchTryCount; // 카드 뒤집은 횟수를 저장할 변수

    private void Awake()
    {
        Time.timeScale = 1.0f;
        gameManager = this;
    }

    void Start()
    {
        // 카드 덱 초기화
        InitiateCard();

        // 변수 초기화
        InitiateValue();
    }

    void Update()
    {
        time -= Time.deltaTime;

        // InGameUI Value 조정
        InGameUI();

        // 첫 번째 카드를 뒤집었다면 5초 후에 다시 뒤집기
        ReturnFlipCard();

        // 잔여 시간이 0초 아래라면 GameEnd() 메소드 실행
        if (time <= 0)
        {
            GameOver();
            Time.timeScale = 0.0f;
        }
    }

    void InGameUI()
    {
        timeText.text = time.ToString("N2");
        matchTryCountText.text = "Count : " + matchTryCount.ToString();

        if (time <= 5)
        {
            timeText.color = Color.red;
        }
    }

    void InitiateCard()
    {
        int[] cardNum = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        cardNum = cardNum.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

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

    void InitiateValue()
    {
        score = 0; // 점수 초기화
        matchTryCount = 0; // matchCount 초기화
    }

    void ReturnFlipCard()
    {
        if (firstCard != null && secondCard == null)
        {
            timeLimit += Time.deltaTime;

            if (timeLimit > 5.0f)
            {
                firstCard.GetComponent<Card>().CloseCardInvoke();
                firstCard = null;
                timeLimit = 0.0f;
            }
        }
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

        if (firstCardImage == secondCardImage) // 같은 카드라면
        {
            managerSource.PlayOneShot(checkSound);

            firstCard.GetComponent<Card>().DestroyCard();
            secondCard.GetComponent<Card>().DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;

            score += 10; // score에 10씩 더하기

            if (cardsLeft == 2)
            {
                Invoke("GameOver", 0.0f);
                PlayerPrefs.SetInt("clear", 0);
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
        else // 다른 카드라면
        {
            timeTextAnimation.MatchFailed();
            // 같은 카드가 아니라면
            time--; // 잔여 시간에서 1초 빼기
            score--; // score에서 1씩 빼기

            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();
            notificationText.SetActive(true);
            notificationText.GetComponent<TextMeshProUGUI>().text = "실패!";
        }

        firstCard = null;
        secondCard = null;
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
      

        inGamePanel.SetActive(false);
        resultPanel.SetActive(true);
        time = 0.00f;
        if (PlayerPrefs.HasKey("bestScore") == false) //최고점수 업데이트
        {

            PlayerPrefs.SetFloat("bestScore", score);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") < score)
            {
                PlayerPrefs.SetFloat("bestScore", score);
            }
        }
        remainTimeText.text = time.ToString("N2");
        tryCountText.text = matchTryCount.ToString();
       
        scoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString();
    }

    
}
