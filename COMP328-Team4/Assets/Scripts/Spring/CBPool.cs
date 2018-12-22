using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBPool : MonoBehaviour
{
    public GameObject CBPrefab;
    public GameObject CBPrefab2;
    public float span;
    private float delta = 0;
    public bool secondTree = false;
    public GameObject STree;

    private Spring_GameController SG;

    // Use this for initialization
    void Start()
    {
        SG = FindObjectOfType<Spring_GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SG.isDead == false)
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject go1 = Instantiate(CBPrefab) as GameObject;
                float py = Random.Range(-5.0f, 6.0f);
                go1.transform.position = new Vector3(9.5f, py, 0);

                if (secondTree)
                {
                    STree.SetActive(true);
                    GameObject go2 = Instantiate(CBPrefab2) as GameObject;
                    float py2 = Random.Range(-5.0f, 6.0f);
                    go2.transform.position = new Vector3(-9.5f, py2, 0);
                }
            }
        }
    }
}
