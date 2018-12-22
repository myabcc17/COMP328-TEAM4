using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer_touchButton : MonoBehaviour {
    Summer_spawnManager spawn_check;
    Summer_Main increment_time;
    Summer_SoundManager sound;
    Summer_ItemManager ItemManager;

    public bool check_boost = false;
    public bool check_lock = false;

    // Use this for initialization
    void Start () {
        spawn_check = GameObject.Find("spawnManager").GetComponent<Summer_spawnManager>();
        increment_time = GameObject.Find("GameHandler").GetComponent<Summer_Main>();
        sound = GameObject.Find("SoundManager").GetComponent<Summer_SoundManager>();
        ItemManager = GameObject.Find("ItemManager").GetComponent<Summer_ItemManager>();
    }
	

	void Update () {

    }

    private void OnMouseDown()
    {

        if (name.Equals("touch_button(Clone)"))
        {
            spawn_check.minus_button_touch_count();
            Destroy(gameObject);
            sound.Play_Touch_Sound();
            increment_time.Increment_time();
            if (ItemManager.get_boost_state())
                spawn_check.set_Spawn(true);
            else if (!ItemManager.get_boost_state() && spawn_check.get_button_count() >= 1)
                spawn_check.set_Spawn(false);
            else
                spawn_check.set_Spawn(true);
        }
        else if(name.Equals("boost(Clone)"))
        {
            Destroy(gameObject);
            //sound.Play_Locked_Sound();
            spawn_check.set_Boost_state(true);
            check_boost = true;
            ItemManager.touch_boostitem();
            ItemManager.set_boost_state(true);
        }
        else if(name.Equals("trap(Clone)"))
        {
            Destroy(gameObject);
            Destroy(GameObject.Find("touch_button(Clone)"));
            sound.Play_Locked_Sound();
            spawn_check.set_Locked_state(true);
            check_lock = true;
            ItemManager.touch_lockitem();
            ItemManager.set_lock_state(true);
        }

    }
    
    public bool get_boost_state()
    {
        return check_boost;
    }
    public bool get_lock_state()
    {
        return check_lock;
    }

}
