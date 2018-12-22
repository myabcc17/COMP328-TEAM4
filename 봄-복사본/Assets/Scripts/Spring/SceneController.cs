using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void onClickSpring()
    {
        SceneManager.LoadScene("Spring_Main");
    }

    public void onClickSummer()
    {
        SceneManager.LoadScene("Summer_Main");
    }

    public void onClickAutumn()
    {
        SceneManager.LoadScene("Autumn_Main");
    }

    public void onClickWinter()
    {
        SceneManager.LoadScene("Winter_Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
