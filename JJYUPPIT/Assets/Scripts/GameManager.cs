using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public TimeText timeTextAnimation;

    public GameObject firstCard;
    public GameObject secondCard;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI matchTryCountText; // 카드 뒤집은 횟수를 Canvas에 보여줄 TMPro

    // 게임 플레이 화면
    public GameObject inGamePanel;

    // 게임 결과창
    public GameObject resultPanel;
    public TextMeshProUGUI remainTimeText; // 남은 시간
    public TextMeshProUGUI tryCountText; // 카드 뒤집기 시도 횟수
    public TextMeshProUGUI scoreText; // 최종 점수
    public TextMeshProUGUI bestScoreText; // 최고 점수

    // 카드 정보창
    public bool isCardInfoPanelOpened;
    public GameObject cardInfoPanel;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardDescriptionText;

    public GameObject card;
    public AudioSource managerSource;
    public AudioClip checkSound;

    private float timeLimit = 0.0f;
    float time = 40f;
    int score; // 게임 점수

    public int matchTryCount; // 카드 뒤집은 횟수를 저장할 변수

    private void Awake()
    {
        Time.timeScale = 1.0f;
        gameManager = this;
        time /= PlayerPrefs.GetInt("diff");
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
        isCardInfoPanelOpened = false; // isCardInfoPanelOpened 초기화
    }

    void ReturnFlipCard()
    {
        if (firstCard != null && secondCard == null)
        {
            timeLimit += Time.deltaTime;

            if (timeLimit > 4.5f)
            {
                firstCard.GetComponent<Card>().CloseCard();
                firstCard.GetComponent<Card>().CardSet();

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

            if (cardsLeft == 2)
            {
                Invoke("GameEnd", 1f);
            }

            // 카드 정보창 호출
            isCardInfoPanelOpened = true;
            StartCoroutine(CallCardInfo(firstCardImage));
        }
        else // 다른 카드라면
        {
            // 같은 카드가 아니라면
            timeTextAnimation.MatchFailed();

            time--; // 잔여 시간에서 1초 빼기
            score--; // score에서 1씩 빼기

            firstCard.GetComponent<Card>().CloseCard();
            secondCard.GetComponent<Card>().CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    // 카드 정보창 세팅
    IEnumerator CallCardInfo(string cardName)
    {
        yield return new WaitForSeconds(0.2f);

        PauseTime(true);

        // 카드 정보 문자열 초기화
        string cardNameInfo = null;
        string cardDescriptionInfo = null;

        // 카드 정보 값 세팅
        if (cardName == "ourpic0")
        {
            cardNameInfo = "배인호";
            cardDescriptionInfo = "우리 집 바보개 #혀수납불가 #바보지만착해요";
        }
        else if (cardName == "ourpic1")
        {
            cardNameInfo = "배인호";
            cardDescriptionInfo = "실력은 부상과 비례한다 #응급실 #골절";
        }
        else if (cardName == "ourpic2")
        {
            cardNameInfo = "이경민";
            cardDescriptionInfo = "최근에 찍은 증명사진";
        }
        else if (cardName == "ourpic3")
        {
            cardNameInfo = "이경민";
            cardDescriptionInfo = "작년 겨울, 신나게 스키를 타는 모습이다. #비발디파크 #겨울이었다";
        }
        else if (cardName == "ourpic4")
        {
            cardNameInfo = "장성민";
            cardDescriptionInfo = "머리를 길렀다. 새로운 증명사진이 필요해. #머리새로함 #상투틀어도될듯";
        }
        else if (cardName == "ourpic5")
        {
            cardNameInfo = "장성민";
            cardDescriptionInfo = "갈색 털이 삐죽삐죽, 귀여운 밤톨이. #밤톨 #포메라니안 #너무귀엽죠";
        }
        else if (cardName == "ourpic6")
        {
            cardNameInfo = "염종인";
            cardDescriptionInfo = "가족들과 강원도에서의 즐거운 요투투어 중에";
        }
        else if (cardName == "ourpic7")
        {
            cardNameInfo = "염종인";
            cardDescriptionInfo = "개발하는 나 #아찍지마 #친구한테도촬당함";
        }

        // 카드 정보 패널 이미지 세팅
        cardInfoPanel.transform.Find("CardImage").GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Images/ourPictures/" + cardName);

        // 카드 정보 패널 문자열 세팅
        cardNameText.text = cardNameInfo;
        cardDescriptionText.text = cardDescriptionInfo;

        // 카드 정보 패널 활성화
        cardInfoPanel.SetActive(true);
    }

    public void PauseTime(bool willPause)
    {
        if (willPause == true)
        {
            Time.timeScale = 0.0f;
        }
        else if (willPause == false)
        {
            Time.timeScale = 1.0f;
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;

        inGamePanel.SetActive(false);
        resultPanel.SetActive(true);
        time = 0.00f;

        // 최고점수 업데이트
        if (PlayerPrefs.GetInt("diff")==1) // Easy Mode 최고점수 업데이트
        {
            if (PlayerPrefs.HasKey("bestScore") == false)
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
            bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString();
        }
        if (PlayerPrefs.GetInt("diff") == 2) // Hard Mode 최고점수 업데이트
        {
            if (PlayerPrefs.HasKey("bestScore1") == false)
            {
                PlayerPrefs.SetFloat("bestScore1", score);
            }
            else
            {
                if (PlayerPrefs.GetFloat("bestScore1") < score)
                {
                    PlayerPrefs.SetFloat("bestScore1", score);
                }
            }
            bestScoreText.text = PlayerPrefs.GetFloat("bestScore1").ToString();
        }

        remainTimeText.text = time.ToString("N2");
        tryCountText.text = matchTryCount.ToString();

        scoreText.text = score.ToString();
        
    }
}
