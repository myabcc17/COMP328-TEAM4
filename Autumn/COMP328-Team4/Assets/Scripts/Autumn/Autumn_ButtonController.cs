using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Autumn_ButtonController : MonoBehaviour
{
    public Autumn_Main main;
    public Text myText;
    public Text firstLeaf;

    public void onClick()
    {
        if (myText.text == firstLeaf.text)
        {
            main.Correct();
        }
        else
        {
            main.NotCorrect();
        }
    }

    public void onClickReplay()
    {
        SceneManager.LoadScene("Autumn_Main");
    }

    public void onClickExit()
    {
        // 이곳에서 그만하는 곳으로 이동
    }
}
