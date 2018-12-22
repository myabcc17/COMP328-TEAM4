using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer_ItemManager : MonoBehaviour {
    Summer_spawnManager spawnManager;

    private float lock_capture_time;
    private float boost_capture_time;
    public bool touch_lockitem_state = false;
    public bool touch_boostitem_state = false;
    // Use this for initialization
    void Start () {
        spawnManager = GameObject.Find("spawnManager").GetComponent<Summer_spawnManager>();

	}
	
	// Update is called once per frame
	void Update () {
		if(touch_lockitem_state)
        {
            if(Time.time - lock_capture_time >= 1.5f)
            {
                spawnManager.set_Spawn(true);
                spawnManager.set_Locked_state(false);
                spawnManager.set_enableSpawn_Locked_state(true);
                touch_lockitem_state = false;
            }
        }
        if(touch_boostitem_state)
        {
            if (Time.time - boost_capture_time >= 3f)
            {
                //spawnManager.clear_button_count();
                spawnManager.set_Boost_state(false);
                spawnManager.set_enableSpawn_Boost_state(true);
                //Destroy(GameObject.Find("touch_button(Clone)"));
                touch_boostitem_state = false;
            }
        }
	}

    public void touch_lockitem()
    {
        lock_capture_time = Time.time;
    }
    public void touch_boostitem()
    {
        boost_capture_time = Time.time;
    }
    public void set_lock_state(bool var)
    {
        touch_lockitem_state = var;
    }
    public void set_boost_state(bool var)
    {
        touch_boostitem_state = var;
    }
    public bool get_lock_state()
    {
        return touch_lockitem_state;
    }
    public bool get_boost_state()
    {
        return touch_boostitem_state;
    }
}
