using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winter_ButtonController : MonoBehaviour
{
    public Winter_Main main;
    public Text myText;
    public int count = 0;

    public void OnClick()
    {
        main.ButtonCheck(myText);
    }
}
