using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summer_Main : MonoBehaviour {
    public Image Timer_bar;
<<<<<<< HEAD
    public int score = 0;
    private Text real_score;
    private Text final_score;
    private GameObject Result_Panel;
    private GameObject Summer_SpawnManager;
    private GameObject Swimming_man;
    private GameObject Shark;
    public float start_x;
    public float distance;
    public float ratio;
    public float var;
	// Use this for initialization
	void Start () {
        Summer_SpawnManager = GameObject.Find("spawnManager");
        real_score = GameObject.Find("Score_실시간").GetComponent<Text>();
        Swimming_man = GameObject.Find("Swimming_man");
        Shark = GameObject.Find("Shark");
        start_x = Swimming_man.transform.position.x;

        Result_Panel = GameObject.Find("ResultPanel");
        Result_Panel.SetActive(false);
=======
    
    public float var;
	// Use this for initialization
	void Start () {

>>>>>>> 0be97f21cce4f03c9e112a5dc745a64bafd9cb30
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        real_score.text = "Score : " + score;

        distance = Swimming_man.transform.position.x - Shark.transform.position.x;
        ratio = (distance) / (start_x - Shark.transform.position.x);

        Vector3 temp = Swimming_man.transform.position;
        temp.x -= 0.01f;
        Swimming_man.transform.position = temp;

        Timer_bar.fillAmount = ratio;
        var = Time.time;
        if(Timer_bar.fillAmount <= 0)
        {
            Summer_SpawnManager.GetComponent<Summer_spawnManager>().Stop_All();
            Destroy(Swimming_man);
            Summer_SpawnManager.SetActive(false);
            print_result();
=======
        Timer_bar.fillAmount -= Time.deltaTime / 60;
        var = Time.time;
        if(Timer_bar.fillAmount <= 0f)
        {

>>>>>>> 0be97f21cce4f03c9e112a5dc745a64bafd9cb30
        }
	}

    public void Increment_x()
    {
        Vector3 temp = Swimming_man.transform.position;
        temp.x += 0.1f;
        Swimming_man.transform.position = temp;
    }
}
