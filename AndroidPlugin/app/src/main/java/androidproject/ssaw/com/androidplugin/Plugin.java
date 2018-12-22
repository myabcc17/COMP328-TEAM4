package androidproject.ssaw.com.androidplugin;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

public class Plugin extends UnityPlayerActivity {

    private MainActivity act = new MainActivity();

    public void receiveFromUnity(String subject, int score) //유니티로부터 값을 받아와 DB로 전송
    {
        act.setInsert(subject,score);
    }

    public void sendToUnity(String subject, int score) //DB의 값을 유니티로 전송
    {
        UnityPlayer.UnitySendMessage("Result", "receiveFromAndroid", subject);
    }
}
