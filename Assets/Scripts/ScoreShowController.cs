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
     private float ScoreBeforeAd;
     private int UpScore;
     public Text UpScoreText;
     private int keta;

     public Animator adAnimator;
    
     // Use this for initialization
     void Start () {
          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();


          //StartCoroutine(ScoreAnimation(0.5f, 1000f, 10000f, 2f));

          LaunchNo.text =  scoreData.GetLaunchNumber().ToString() + "号機";
          StartCoroutine("PointRateAdd");

          adAnimator = GameObject.Find("AdDialog").GetComponent<Animator>();
          UpScoreText = GameObject.Find("DetailText").GetComponent<Text>();

         // StartCoroutine(ScoreAnimation(0.5f, 0.0f, scoreData.GetScoreNow(), 1.0f));

     }

     // Update is called once per frame
     void Update () {
	
	}
     
     void ShowAdDialog()  // unityの動画広告を見るかどうか判断させる
     {
          //Debug.Log("ShowAd?");
                   

          UpScore = (int) (scoreData.GetScore() * Random.Range(0.2f,1.2f));
          keta = Mathf.Max(GetDigit(UpScore) -2 , 0);
          UpScore = (int) (Mathf.Round(UpScore / Mathf.Pow(10, keta)) * Mathf.Pow(10, keta));

          
          Debug.Log("keta:" + keta);
          Debug.Log("UpScore:" + UpScore);

          UpScoreText.text = "短時間の動画広告を表示させると、/nスコアを" + UpScore + "point増やすことが出来ます。/n広告を見ますか？";
          adAnimator.SetBool("Up" , true);
         
     }

     public void AfertShowAd()
     {
          StartCoroutine(ScoreAnimation(0.5f, ScoreBeforeAd, ScoreBeforeAd + UpScore, 1.0f));
     }

     
     public static int GetDigit(int num)
     {
          return (num == 0) ? 1 : (int)Mathf.Log10(num) + 1;
     }

     private IEnumerator PointRateAdd()
     {
          yield return StartCoroutine(DistanceAnimation(0.5f, 0.0f, scoreData.GetScoreNow(), 1.0f));
   
          yield return StartCoroutine(RateAnimation(0.5f, 0.0f, scoreData.GetScoreCoefficient(), 1.0f));

          ScoreBeforeAd = scoreData.GetScoreNow() * scoreData.GetScoreCoefficient();

          yield return StartCoroutine(ScoreAnimation(0.5f, 0.0f, ScoreBeforeAd, 1.0f));

      
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

          if (Random.value <= 1.0f)  //ランダムでこれ以下なら広告のダイアログを出す
          {
               ShowAdDialog();

          }
     }




   
}
