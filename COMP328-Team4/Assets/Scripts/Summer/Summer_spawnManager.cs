using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer_spawnManager : MonoBehaviour {
    public bool enableSpawn = false;
    public GameObject touch_button;

    public void set_Spawn(bool val)
    {
        enableSpawn = val;
    }
    void SpawnButton()
    {
        float randomX = Random.Range(-0.5f, 0.5f);
        if(enableSpawn)
        {
            GameObject button = (GameObject)Instantiate(touch_button, new Vector3(randomX, 1.1f, 0f), Quaternion.identity);
            enableSpawn = false;
        }
    }
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnButton", 2, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
