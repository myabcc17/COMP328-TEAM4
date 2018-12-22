using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugin : MonoBehaviour
{
    private string score;
    private AndroidJavaObject ajo = null;

    // Start is called before the first frame update
    void Start() //안드로이드 스튜디오와 연동
    {
        TextMesh textMesh = GetComponent<TextMesh>();
        var plugin = new AndroidJavaClass("androidproject.ssaw.com.androidplugin.plugin");
        textMesh.text = plugin.CallStatic<string>("sendToUnity", score);
    }

    public int sendToGameScore(string score) //안드로이드 스튜디오 DB에서 받아온 점수 씬으로 전송
    {
        return int.Parse(score);
    }

    public void sendToAndroid(string score) //안드로이드 스튜디오로 점수값 전송
    {
        using (AndroidJavaClass pluginClass = new AndroidJavaClass("androidproject.ssaw.com.androidplugin.plugin"))
        {
            if(pluginClass != null)
            {
                ajo = pluginClass.CallStatic<AndroidJavaObject>("instance");
                ajo.Call("ReceiveFromUinty", score);
                ajo.Call("runOnUIThread", new AndroidJavaRunnable(() =>
                 {
                     ajo.Call("showMessage", "성공");
                 }));
            }
        }
    }
}
