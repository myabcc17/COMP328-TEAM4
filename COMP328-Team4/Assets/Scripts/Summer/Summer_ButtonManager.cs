using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Summer_ButtonManager : MonoBehaviour {

    public void OnClick_Regame()
    {
        SceneManager.LoadScene("Summer_Main");
    }
    public void OnClick_Exit()
    {
        SceneManager.LoadScene("게임선택");
    }
}