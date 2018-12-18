using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer_touchButton : MonoBehaviour {
    Summer_spawnManager spawn_check;
	// Use this for initialization
	void Start () {
        spawn_check = GameObject.Find("spawnManager").GetComponent<Summer_spawnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0 || Input.GetKey(KeyCode.Mouse0))
        {
            Destroy(gameObject);
            spawn_check.set_Spawn(true);
        }
	}
}
