using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
