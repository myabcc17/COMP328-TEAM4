using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winter_ButtonController : MonoBehaviour
{
    public Winter_Main main;
    public Text myText;
    public int count = 0;
    public AudioSource touchSound;
    public void OnClick()
    {
        touchSound.Play();
        main.ButtonCheck(myText);
    }
}
