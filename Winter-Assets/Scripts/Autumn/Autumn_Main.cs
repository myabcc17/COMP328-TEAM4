using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Autumn_Main : MonoBehaviour
{
    public Sprite[] leafObj = new Sprite[6]; // 나뭇잎 이미지 파일 6개 저장
    public GameObject[] leaves = new GameObject[6]; // 버튼 6개 = 나뭇잎 버튼
    private int[] leafNumber = new int[6]; // 잎 랜덤 저장 배열
    public Text[] leavesText = new Text[6]; // 버튼 6개에 달려있는 텍스트
    public GameObject[] fallingLeaves = new GameObject[8]; // 내려오는 잎들
    public Text[] leavesSequence = new Text[8]; // 내려오는 잎들 번호 배열
    private int level; // level=1~level=3
    private float score; // 점수
    private int readyToLevelUp; // 레벨업 준비 변수
    private int click;
    private float fullTime; // 전체 시간
    private float currentTime; // 타이머 시간
    private float fever;
    public Text timer;
    public Text score_text;
    public Text combo_text;

    void Start()
    {
        click = 0;
        score = 0;
        level = 1;
        readyToLevelUp = 1;
        fever = 1.0f;
        currentTime = 60;
        fullTime = 60;

        RandomLeaves();
        LeafSetActive();
        SetLeavesAligned();
        StartCoroutine("LevelUp");
    }

    void RandomLeaves() // 버튼마다 잎 랜덤으로 배정하기
    {
        float rand;
        int n;
        int[] booleaf = new int[6];
        for (int i = 0; i < 6; i++) // 잎 중복확인하는 배열 0으로 초기화
            booleaf[i] = -1;

        for (int i = 0; i < 6; i++)
        {
            rand = Random.value; // 랜덤 숫자 하나 생성하기
            n = ((int)(rand * 10) % 6);

            while (booleaf[n] != -1)
            {
                rand = Random.value;
                n = ((int)(rand * 10) % 6);
            }

            booleaf[n] = 1;

            leaves[i].GetComponent<Image>().sprite = leafObj[n];
            leavesText[i].text = n + ""; // leavesText에 해당 leaf의 번호 지정해놓기
            leafNumber[i] = n;
        }

        /*for (int i = 0; i < 6; i++) //순서검사
            print(leafNumber[i]);*/
    }

    void LeafSetActive() // 해당 level의 leaves Set Active
    {
        for (int i = (level - 1) * 2; i < (level * 2); i++)
            leaves[i].SetActive(true);
    }

    void SetLeavesAligned() // 초기에 낙엽들 정렬하기
    {
        float rand;
        int n;
        for (int i = 0; i < 8; i++)
        {
            rand = Random.value;

            if (0 <= rand && rand < 0.5) // 초기이므로 0~1로 값을 정해서 할당
                n = 0;
            else
                n = 1;

            fallingLeaves[i].GetComponent<Image>().sprite = leafObj[leafNumber[n]];
            leavesSequence[i].text = leafNumber[n] + ""; // 내려온 leaves 순서들을 저장해놓기
        }
    }

    public void Correct() // 클릭을 맞췄을 경우
    {
        for (int i = 0; i < 7; i++) // 맞출경우 8개중 2~8번째꺼를 한칸씩 내려서 1~7번째 잎들로 맞춤
        {
            leavesSequence[i].text = leavesSequence[i + 1].text;
            string temp = (string)leavesSequence[i].text;
            int n = int.Parse(temp);
            fallingLeaves[i].GetComponent<Image>().sprite = leafObj[n];
        }

        float rand = Random.value; // 그리고는 랜덤으로 잎 하나 추가
        int m = ((int)(rand * 10)) % (level * 2);
        leavesSequence[7].text = leafNumber[m] + "";
        fallingLeaves[7].GetComponent<Image>().sprite = leafObj[leafNumber[m]];

        click++;// 연속 클릭 성공 횟수
        if (click % 50 == 0)
            FeverUp();
        score += 10 * fever;
        if (score >= 1500)
            readyToLevelUp = 1;
    }

    public void NotCorrect() // 실패 했을 경우
    {
        click = 0;
        fever = 1;
        combo_text.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f); //글씨 색깔 검은색, 크기 원래 크기
        combo_text.fontSize = 100;
        StartCoroutine("BlockButton"); // 버튼 클릭 잠시 막기
    }

    public void FeverUp()
    {
        if (fever <= 2.0)
            fever += 0.05f;
        else if (2.0 < fever && fever <= 3.0)
            fever += 0.1f;
        else
            fever += 0.15f;

        currentTime += 10;

        combo_text.fontSize += 25; //Fever 들어가면 콤보 글자 크기 25증가, 색깔 조금씩 바꾸기
        if (100 * fever < 255)
            combo_text.color = new Color(255.0f / 255.0f, (100 * fever) / 255.0f, 100.0f / 255.0f);
        else
            combo_text.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 100.0f / 255.0f);
    }

    public void GameOver()
    {

    }

    IEnumerator BlockButton() // 버튼 2초가량 사라지게 만듬
    {
        for (int i = 0; i < 6; i++)
            leaves[i].SetActive(false);

        yield return new WaitForSeconds(2.0f);

        for (int i = 0; i < (level * 2); i++)
            leaves[i].SetActive(true);
    }

    IEnumerator LevelUp()
    {
        yield return new WaitUntil(() => (score >= 750) && readyToLevelUp == 1);
        level++;
        readyToLevelUp = 0;
        LeafSetActive();
        if (level < 3)
            StartCoroutine("LevelUp");
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timer.text = "Time : " + currentTime.ToString("F");
            if (currentTime <= 0)
                GameOver();
        }

        score_text.text = "Score : " + score.ToString("F");
        combo_text.text = "" + click;
    }
}
