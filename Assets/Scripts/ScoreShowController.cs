using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreShowController : MonoBehaviour {

     public ScoreData scoreData;
     public Text maxHight;
     public Text PointRate;
     public Text Point;
     public Text Etc;
     public Text LaunchNo;
     public Text scoreText;
    
     // Use this for initialization
     void Start () {


          //StartCoroutine(ScoreAnimation(0.5f, 1000f, 10000f, 2f));

          LaunchNo.text =  scoreData.GetLaunchNumber().ToString() + "号機";
          StartCoroutine("PointRateAdd");

         // StartCoroutine(ScoreAnimation(0.5f, 0.0f, scoreData.GetScoreNow(), 1.0f));

     }

     // Update is called once per frame
     void Update () {


	
	}

     private IEnumerator PointRateAdd()
     {
          yield return StartCoroutine(DistanceAnimation(0.5f, 0.0f, scoreData.GetScoreNow(), 1.0f));
   
          yield return StartCoroutine(RateAnimation(0.5f, 0.0f, scoreData.GetScoreCoefficient(), 1.0f));

          yield return StartCoroutine(ScoreAnimation(0.5f, 0.0f, scoreData.GetScoreNow() * scoreData.GetScoreCoefficient(), 1.0f));

      
     }

     // 距離をアニメーションさせる
     private IEnumerator DistanceAnimation(float WaitTime, float startScore, float endScore, float duration)
     {
          //　動く前にひと呼吸
          yield return new WaitForSeconds(WaitTime);

          // 開始時間
          float startTime = Time.time;

          // 終了時間
          float endTime = startTime + duration;

          GetComponent<AudioSource>().Play();

          do
          {
               // 現在の時間の割合
               float timeRate = (Time.time - startTime) / duration;

               // 数値を更新
               float updateValue = (float)((endScore - startScore) * timeRate + startScore);

               // テキストの更新
               maxHight.text = updateValue.ToString("f2") + " m"; // ("f0" の "0" は、小数点以下の桁数指定)

               // 1フレーム待つ
               yield return null;

          } while (Time.time < endTime);

          // 最終的な着地のスコア
          maxHight.text = endScore.ToString("f2") + " m";
          GetComponent<AudioSource>().Stop();
     }

     // 係数をアニメーションさせる
     private IEnumerator RateAnimation(float WaitTime, float startScore, float endScore, float duration)
     {
          //　動く前にひと呼吸
          yield return new WaitForSeconds(WaitTime);

          // 開始時間
          float startTime = Time.time;

          // 終了時間
          float endTime = startTime + duration;

          GetComponent<AudioSource>().Play();

          do
          {
               // 現在の時間の割合
               float timeRate = (Time.time - startTime) / duration;

               // 数値を更新
               float updateValue = (float)((endScore - startScore) * timeRate + startScore);

               // テキストの更新
               PointRate.text = "✕" + updateValue.ToString("f2"); // ("f0" の "0" は、小数点以下の桁数指定)

               // 1フレーム待つ
               yield return null;

          } while (Time.time < endTime);

          // 最終的な着地のスコア
          PointRate.text = "✕" +  endScore.ToString("f2") ;
          GetComponent<AudioSource>().Stop();
     }

     // スコアをアニメーションさせる
     private IEnumerator ScoreAnimation(float WaitTime, float startScore, float endScore, float duration)
     {
          //　動く前にひと呼吸
          yield return new WaitForSeconds(WaitTime);

          // 開始時間
          float startTime = Time.time;

          // 終了時間
          float endTime = startTime + duration;

          GetComponent<AudioSource>().Play();

          do
          {
               // 現在の時間の割合
               float timeRate = (Time.time - startTime) / duration;

               // 数値を更新
               float updateValue = (float)((endScore - startScore) * timeRate + startScore);

               // テキストの更新
               scoreText.text = updateValue.ToString("f2") + " point"; // ("f0" の "0" は、小数点以下の桁数指定)

               // 1フレーム待つ
               yield return null;

          } while (Time.time < endTime);

          // 最終的な着地のスコア
          scoreText.text = endScore.ToString("f2") + " point";
          GetComponent<AudioSource>().Stop();
     }

   
}
