using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class ScoreData : MonoBehaviour {

     public float TotalDistance; // 今まで飛んだ距離
     public float ScoreNow;   // 今回のスコア
     public float TotalScore;    // 今までのトータルのスコア
     public float Score;           // 今のスコア
     public float ScoreCoefficient; // 距離をスコアにする係数。アイテムで増えたりする。
     public int LaunchNumber;      // 打ち上げ回数
     public float MaxDistance;      //今までの最高高度


     void Awake()
     {
          LoadScore();
     }

     // Use this for initialization
     void Start () {
          //TotalDistance = PlayerPrefs.GetFloat("TotalDistance", 0.0f);
          //TotalScore = PlayerPrefs.GetFloat("TotalScore", 0.0f);
          //ScoreNow = PlayerPrefs.GetFloat("ScoreNow", 0.0f);
          //Score = PlayerPrefs.GetFloat("Score", 0.0f);
          //ScoreCoefficient = PlayerPrefs.GetFloat("ScoreCoefficient", 1.0f);
          //LaunchNumber = PlayerPrefs.GetInt("LaunchNumber", 0);
          //MaxDistance = PlayerPrefs.GetFloat("MaxDistance", 0);
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void SaveScore()
     {
          PlayerPrefs.SetFloat("TotalDistance", TotalDistance);
          PlayerPrefs.SetFloat("TotalScore", TotalScore);
          PlayerPrefs.SetFloat("ScoreNow", ScoreNow);
          PlayerPrefs.SetFloat("Score", Score);
          PlayerPrefs.SetFloat("ScoreCoefficient", ScoreCoefficient);
          PlayerPrefs.SetInt("LaunchNumber", LaunchNumber);
          PlayerPrefs.SetFloat("MaxDistance", MaxDistance);

          PlayerPrefs.Flush();

     }

     public void LoadScore()
     {
          TotalDistance = PlayerPrefs.GetFloat("TotalDistance", 0.0f);
          TotalScore = PlayerPrefs.GetFloat("TotalScore", 200.0f);
          ScoreNow = PlayerPrefs.GetFloat("ScoreNow", 0.0f);
          Score = PlayerPrefs.GetFloat("Score", 0.0f);
          ScoreCoefficient = PlayerPrefs.GetFloat("ScoreCoefficient", 1.0f);
          LaunchNumber = PlayerPrefs.GetInt("LaunchNumber", 0);
          MaxDistance = PlayerPrefs.GetFloat("MaxDistance", 0);
     }

     public void CalcNewScore (float AddDistance) // 距離を加える
     {
          Score = AddDistance * ScoreCoefficient;
          TotalDistance = TotalDistance + AddDistance;
          TotalScore = TotalScore  + AddDistance * ScoreCoefficient;

          SaveScore();

     }

     public void CalcScoreUse(float Price) // 買い物してスコアを減らす
     {
          Score =- Price;                    
          SaveScore();

     }

     public void CalcMaxDistance(float Hight)  //最大高度を更新する
     {
          if (Hight > MaxDistance)
          {
               //Debug.Log("Max" + MaxDistance);
               //Debug.Log("Score" + Hight);
               MaxDistance = Hight;
               //Debug.Log("Max" + MaxDistance);
               PlayerPrefs.SetFloat("MaxDistance", MaxDistance);
          }
          
     }

     public float GetTotalScore()
     {
          return TotalScore;
     }

     public float GetScoreNow()
     {
          return ScoreNow;
     }

     public float GetTotalDistance()
     {
          return TotalDistance;
     }

     public float GetScore()
     {
          return Score;
     }

     public float GetScoreCoefficient()
     {
          return ScoreCoefficient;
     }

     public void AddScoreCoefficient(float AddCoefficient)
     {
          ScoreCoefficient = ScoreCoefficient + AddCoefficient;
          SaveScore();
     }

     public int GetLaunchNumber()
     {
          return LaunchNumber;
     }

     public float GetMaxDistance()
     {
          return MaxDistance;
      }

     public void AddLaunchNumber()
     {
          LaunchNumber ++ ;
          SaveScore();
     }
}
