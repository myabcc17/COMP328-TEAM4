using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Spring_GameController SG;

    // Start is called before the first frame update
    void Start()
    {
        SG = FindObjectOfType<Spring_GameController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CB")
        {
            Debug.Log("사망");
            SG.isDead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
