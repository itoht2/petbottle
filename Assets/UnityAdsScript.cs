using UnityEngine;
using System.Collections;

// ここの追加を忘れずに。
using UnityEngine.Advertisements;

public class UnityAdsScript : MonoBehaviour {

	void Awake()
    {   
        // まずはAwake()内で、初期化をします。先ほどのゲームIDを入力。
        Advertisement.Initialize ("1153612");
    }

    public void ShowAd() {
        // 広告再生の準備ができているか確認。
        if (Advertisement.IsReady()) 
            // 準備ができていたら、広告再生。
            Advertisement.Show();
    }
}
