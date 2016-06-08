using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GarageController : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;
     public int TotalScore;
     public Text TotalScoreText;

	// Use this for initialization
	void Start () {
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();

          TotalScore = (int)scoreData.GetTotalScore();

          //TotalScoreText.text = "スコア: " + TotalScore +" point";
          StartCoroutine(ScoreAnimation(0f, TotalScore, 1f));

     }
	
	// Update is called once per frame
	void Update () {
	
	}

     // スコアをアニメーションさせる
     public IEnumerator ScoreAnimation(float startScore, float endScore, float duration)
     {
          // 開始時間
          float startTime = Time.time;

          // 終了時間
          float endTime = startTime + duration;

          do
          {
               // 現在の時間の割合
               float timeRate = (Time.time - startTime) / duration;

               // 数値を更新
               float updateValue = (float)((endScore - startScore) * timeRate + startScore);

               // テキストの更新
               TotalScoreText.text = "スコア: " + updateValue.ToString("f0") + " point"; // ("f0" の "0" は、小数点以下の桁数指定)

               // 1フレーム待つ
               yield return null;

          } while (Time.time < endTime);

          // 最終的な着地のスコア
          TotalScoreText.text = "スコア: " + endScore.ToString() + " point"; ;
     }
}
