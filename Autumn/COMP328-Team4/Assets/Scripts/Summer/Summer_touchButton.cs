using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer_touchButton : MonoBehaviour {
    Summer_spawnManager spawn_check;
    Summer_Main Summer_Main;
    Summer_SoundManager sound;
    Summer_ItemManager ItemManager;

    public bool check_boost = false;
    public bool check_lock = false;

    // Use this for initialization
    void Start () {
        spawn_check = GameObject.Find("spawnManager").GetComponent<Summer_spawnManager>();
        Summer_Main = GameObject.Find("GameHandler").GetComponent<Summer_Main>();
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
            Summer_Main.Increment_x();
            Summer_Main.Add_Score();

            if (!ItemManager.get_lock_state() && spawn_check.get_button_count() < 1)
                spawn_check.set_Spawn(true);
            else if (ItemManager.get_boost_state() && spawn_check.get_button_count() >= 3)
                spawn_check.set_Spawn(false);
            else if (ItemManager.get_lock_state())
                spawn_check.set_Spawn(false);

        }
        else if(name.Equals("boost(Clone)"))
        {
            Destroy(gameObject);
            spawn_check.set_Boost_state(true);
            spawn_check.set_Spawn(true);
            ItemManager.set_boost_state(true);
            check_boost = true;
            ItemManager.touch_boostitem();
        }
        else if(name.Equals("trap(Clone)"))
        {
            spawn_check.set_Locked_state(true);
            spawn_check.set_enableSpawn_Boost_state(false);
            sound.Play_Locked_Sound();
            ItemManager.set_lock_state(true);
            check_lock = true;
            ItemManager.touch_lockitem();
            for (int i = 0; i < 3; i++)
            {
                Destroy(GameObject.Find("touch_button(Clone)"));
                spawn_check.minus_button_touch_count();
            }
            Destroy(gameObject);
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
