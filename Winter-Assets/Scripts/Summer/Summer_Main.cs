using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summer_Main : MonoBehaviour {
    public Image Timer_bar;
    
    public float var;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Timer_bar.fillAmount -= Time.deltaTime / 60;
        var = Time.time;
        if(Timer_bar.fillAmount <= 0f)
        {

        }
	}

    public void Increment_time()
    {
        Timer_bar.fillAmount += Time.deltaTime / 20;
    }
}
