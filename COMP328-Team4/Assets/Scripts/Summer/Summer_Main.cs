using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summer_Main : MonoBehaviour {
    public Image Timer_bar;
    public int score = 0;
    private Text real_score;
    private Text final_score;
    private GameObject Result_Panel;
    private GameObject Summer_SpawnManager;
    public float var;
	// Use this for initialization
	void Start () {
        Summer_SpawnManager = GameObject.Find("spawnManager");
        real_score = GameObject.Find("Score_실시간").GetComponent<Text>();
        Result_Panel = GameObject.Find("ResultPanel");
        Result_Panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        real_score.text = "Score : " + score;

        Timer_bar.fillAmount -= Time.deltaTime;
        var = Time.time;
        if(Timer_bar.fillAmount == 0)
        {
            Summer_SpawnManager.GetComponent<Summer_spawnManager>().Stop_All();
            Summer_SpawnManager.SetActive(false);
            print_result();
        }
	}

    public void Increment_time()
    {
        Timer_bar.fillAmount += Time.deltaTime / 20;
    }

    public void Add_Score()
    {
        score += 10;
    }

    private void print_result()
    {
        Result_Panel.SetActive(true);
        final_score = GameObject.Find("Final_Score").GetComponent<Text>();
        final_score.text = "Final_Score : " + score;
    }


}
