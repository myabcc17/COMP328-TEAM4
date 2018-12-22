using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spring_GameController : MonoBehaviour
{
    public Transform target = null;
    private Vector3 Click_Point;
    Collider2D Click_Coll;
    public GameObject player;
    private float timer;    
    public Text timerText;
    public bool isDead = false;
    private string score;
    public GameObject resultPanel;
    public Text resultText;
    private Vector3 startPos;

    private CBPool cbPool;

    // Use this for initialization
    void Start()
    {
        cbPool = FindObjectOfType<CBPool>();
        startPos = target.position;
    }

    public void onClickReplayBtn()
    {
        target.position = startPos;
        timer = 0;
        resultPanel.SetActive(false);
        isDead = false;
    }

    public void onClickBackBtn()
    {
        SceneManager.LoadScene("게임선택");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            timer += Time.deltaTime;
            timerText.text = "Time : " + timer.ToString("n2");

            if (Input.GetMouseButton(0))  // 마우스가 클릭 되면
            {
                Vector3 pos = Input.mousePosition;
                pos.z = Camera.main.farClipPlane;
                Click_Point = Camera.main.ScreenToWorldPoint(pos); // 마우스 좌표 저장
                Click_Coll = Physics2D.OverlapPoint(Click_Point); // 마우스 클릭한 좌표에 캐릭터 있는지
                if (Click_Coll) // 캐릭터 클릭했으면
                {
                    if (Click_Coll.gameObject == player)
                    {
                        target.position = Click_Point; // 캐릭터 위치 이동
                    }
                }
            }
            // 시간별 난이도 증가
            if (timer > 15f && timer < 30f)
            {
                cbPool.span = 0.7f;
            }
            else if (timer > 30f && timer < 60f)
            {
                cbPool.span = 0.5f;
            }
            else if (timer > 60f && timer < 75f)
            {
                cbPool.secondTree = true;
                cbPool.span = 0.7f;
            }
            else if (timer > 75f && timer < 90f)
            {
                cbPool.span = 0.5f;
            }
            else if (timer > 90f && timer < 105f)
            {
                cbPool.span = 0.3f;
            }
        }
        else
        {
            score = timer.ToString("n2");
            timerText.text = "";
            resultText.text = "Score: " + score;
            resultPanel.SetActive(true);
        }
    }
}
