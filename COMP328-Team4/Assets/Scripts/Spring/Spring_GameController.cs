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
    private float timer = 0;    
    public Text timerText;
    public bool isDead = false;
    private string score;
    public GameObject resultPanel;
    public Text resultText;
    private Vector3 startPos;
    public AudioSource BGM;

    private CBPool cbPool;

    // Use this for initialization
    void Start()
    {
        cbPool = FindObjectOfType<CBPool>();
        startPos = target.position;
        BGM.Play();
    }

    public void onClickReplayBtn()
    {
        resultPanel.SetActive(false);
        SceneManager.LoadScene("Spring_Main");
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
            if (timer > 10f && timer < 20f)
            {
                cbPool.span = 0.7f;
            }
            else if (timer > 20f && timer < 30f)
            {
                cbPool.span = 0.5f;
            }
            else if (timer > 30f && timer < 40f)
            {
                cbPool.span = 0.3f;
            }
            else if (timer > 40f && timer < 50f)
            {
                cbPool.secondTree = true;
                cbPool.span = 0.7f;
            }
            else if (timer > 50f && timer < 60f)
            {
                cbPool.span = 0.5f;
            }
            else if(timer > 60f)
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
