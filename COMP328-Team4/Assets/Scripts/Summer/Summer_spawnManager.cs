using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Summer_spawnManager : MonoBehaviour {
    Summer_touchButton lock_scripts = null;
    Summer_touchButton boost_scripts = null;

    public bool enableSpawn = false;
    public bool enableSpawn_Boost = false;
    public bool enableSpawn_Locked = false;
    public bool enableBoost = false;
    public bool Locked = false;

    private float x_min = -5f, x_max = 5f;
    private float y_min = -3f, y_max = 3f;


    public GameObject touch_button;
    public GameObject boost_item;
    public GameObject lock_item;

    public int button_count = 0;

    public void set_Spawn(bool val)
    {
        enableSpawn = val;
    }
    public void set_Boost_state(bool val)
    {
        enableBoost = val;
    }
    public void set_Locked_state(bool val)
    {
        Locked = val;
    }
    public void set_enableSpawn_Locked_state(bool val)
    {
        enableSpawn_Locked = val;
    }
    public void set_enableSpawn_Boost_state(bool val)
    {
        enableSpawn_Boost = val;
    }
    public void minus_button_touch_count()
    {
        button_count -= 1;
    }
    public void clear_button_count()
    {
        button_count = 0;
    }
    public int get_button_count()
    {
        return button_count;
    }
    void Spawn_TouchButton()
    {
        float randomX = Random.Range(x_min, x_max);
        float randomY = Random.Range(y_min, y_max);

        if (enableSpawn)
        {
            // Boost 모드아닐때는 버튼 1개만 나타남.
            if (!enableBoost)
            {
                GameObject Touch_Button = (GameObject)Instantiate(touch_button, new Vector3(randomX, randomY, 0f), Quaternion.identity);
                enableSpawn = false;
                button_count += 1;

            }
            // Boost 모드일때는 버튼 2개 나타남.
            else
            {
                if (button_count < 3)
                {
                    GameObject Touch_Button = (GameObject)Instantiate(touch_button, new Vector3(randomX, randomY, 0f), Quaternion.identity);
                    button_count += 1;
                    if (button_count == 3)
                        enableSpawn = false;
                }
            }
        }

    }
    /* 
     * Lock버튼은 게임시작 10초후부터 랜덤한 간격으로 나온다.
     * Lock버튼은 단 한개만 나온다.
     * Lock버튼이 나오고 1초안에 터치를 하지 않으면 사라진다.
     * Lock버튼이 작동되면 어떤 버튼도 1.5초동안 나오지 않는다.
    */
    void Spawn_Lock_Item()
    {

        float randomX = Random.Range(x_min, x_max);
        float randomY = Random.Range(y_min, y_max);

        if (enableSpawn_Locked)
        {
            GameObject Lock_Item = (GameObject)Instantiate(lock_item, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            enableSpawn_Locked = false;
            lock_scripts = GameObject.Find("trap(Clone)").GetComponent<Summer_touchButton>();
            StartCoroutine("WaitSecond_spawn_lock");

        }
    }

    /* 
     * Boost버튼은 게임시작 10초후부터 랜덤한 간격으로 나온다.
     * Boost버튼은 단 한개만 나온다.
     * Boost가 작동되면 Touch_button은 최대 2개까지 나온다.
     * Boost버튼이 나타나고 1초안에 터치하지 못하면 사라진다.
     * Boost시간은 3초이다.
    */
    private void Spawn_Boost_Item()
    {

        float randomX = Random.Range(x_min, x_max);
        float randomY = Random.Range(y_min, y_max);

        if (enableSpawn_Boost)
        {
            GameObject Boost_Item = (GameObject)Instantiate(boost_item, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            enableSpawn_Boost = false;
            boost_scripts = GameObject.Find("boost(Clone)").GetComponent<Summer_touchButton>();
            StartCoroutine("WaitSecond_spawn_boost");
            if (boost_scripts.get_boost_state())
                StopCoroutine("WaitSecond_spawn_boost");
        }
    }
    // Use this for initialization
    void Start () {

        float lock_random = Random.Range(4f, 6f);
        float boost_random = Random.Range(4f, 6f);

        InvokeRepeating("Spawn_TouchButton", 0, 0.3f);
        InvokeRepeating("Spawn_Lock_Item", 5, lock_random);
        InvokeRepeating("Spawn_Boost_Item", 3, boost_random);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitSecond_spawn_boost()
    {
        yield return new WaitForSeconds(1);

        // 1초안에 boost item을 터치를 안했으면? 파괴
        if (!boost_scripts.get_boost_state())
        {
            Destroy(GameObject.Find("boost(Clone)"));
            enableSpawn_Boost = true;
        }
        else
        {
            StopCoroutine("WaitSecond_boost_lock");
        }
    }

    IEnumerator WaitSecond_spawn_lock()
    {
        yield return new WaitForSeconds(1);

        // 1초안에 lock item을 터치를 안했으면? 파괴
        if (!lock_scripts.get_lock_state())
        {
            Destroy(GameObject.Find("trap(Clone)"));
            enableSpawn_Locked = true;
        }
        else
        {
            StopCoroutine("WaitSecond_spawn_lock");
        }
    }

    public void Stop_All()
    {
        CancelInvoke();
        StopCoroutine("WaitSecond_spawn_lock");
        StopCoroutine("WaitSecond_boost_lock");
        Destroy(GameObject.Find("touch_button(Clone)"));
        Destroy(GameObject.Find("boost(Clone)"));
        Destroy(GameObject.Find("trap(Clone)"));

    }
}

