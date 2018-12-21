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
        // 이지원이 여기서 메인화면 가는 코드만 넣기.
    }
}