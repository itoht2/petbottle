using UnityEngine;
using System.Collections;
using PlayerPrefs = PreviewLabs.PlayerPrefs;
using System;

public class ScoreData : MonoBehaviour {

     public float TotalDistance; // 今まで飛んだ距離
     public float ScoreNow;   // 今回のスコア
     public float TotalScore;    // 今までのトータルのスコア
     public float Score;           // 今のスコア
     public float ScoreCoefficient; // 距離をスコアにする係数。アイテムで増えたりする。
     public int LaunchNumber;      // 打ち上げ回数
     public float MaxDistance;      //今までの最高高度
     public DateTime LastDate;     // 前回のプレイ日付
     public DateTime TodayDate;    // 今日
     public int NumberOfDays = 1;      //  プレイ日数
     public int NumbrtOfDaysContinue = 1;   //   連続日数

     public float HiScoreBonus;         // 最高高度を超えたときのボーナス
     public float EjectBonus;           //　ペイロード放出ボーナス

     void Awake()
     {
          LoadScore();
     }

     // Use this for initialization
     void Start () {
          TimeSpan ts = TodayDate - LastDate;
          if (LastDate == new DateTime(0001, 1, 1, 0, 0, 0) )
          {
               //Debug.Log("最初");
               NumberOfDays = 1;
               NumbrtOfDaysContinue = 1;
          } else if (ts.Days < 1) {
               //Debug.Log("同日");

          } else if (ts.Days == 1)
          {
               NumberOfDays ++;
               NumbrtOfDaysContinue ++;
               //Debug.Log("連日");

          } else if (ts.Days > 1)
          {
               NumberOfDays ++;
               NumbrtOfDaysContinue = 1;
               //Debug.Log("離れた日");

          }

          HiScoreBonus = 0.0f;
          EjectBonus = 0.0f;

          SaveScore();

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
          PlayerPrefs.SetString("LastDate", TodayDate.ToBinary().ToString());
          PlayerPrefs.SetInt("NumberOfDays", NumberOfDays);
          PlayerPrefs.SetInt("NumberOfDaysContinue", NumbrtOfDaysContinue);

          //PlayerPrefs.Flush();

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

          string datetimeString = PlayerPrefs.GetString("LastDate");
          LastDate = System.DateTime.FromBinary(System.Convert.ToInt64(datetimeString));
          //Debug.Log(LastDate);
          TodayDate = DateTime.Today;
          NumberOfDays = PlayerPrefs.GetInt("NumberOfDays", 1);
          NumbrtOfDaysContinue = PlayerPrefs.GetInt("NumberOfDaysContinue", 1);
          

     }

     public void CalcNewScore (float AddDistance) // 距離を加える
     {
         

          Score = AddDistance * ScoreCoefficient;
          //Debug.Log("score:" + Score);
          //Debug.Log("AddDis:" + AddDistance);
          //Debug.Log("ScoreCoeff:" + ScoreCoefficient);
          TotalDistance = TotalDistance + AddDistance;
          //TotalScore = TotalScore  + AddDistance * ScoreCoefficient;

          SaveScore();

     }

     public void CalcScoreUse(float Price) // 買い物してスコアを減らす
     {
          Score =- Price;                    
          SaveScore();
          PlayerPrefs.Flush();

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
          PlayerPrefs.Flush();
     }

     public int GetLaunchNumber()
     {
          return LaunchNumber;
     }

     public float GetMaxDistance()
     {
          return MaxDistance;
      }
     public int GetNumberOfDays()
     {
          return NumberOfDays;
     }
     public int GetNumbrtOfDaysContinue()
     {
          return NumbrtOfDaysContinue;
     }

     public float GetHiScoreBonus()
     {
          return HiScoreBonus;
     }

     public float GetEjectBonus()
     {
          return EjectBonus;
     }

     public void AddLaunchNumber()
     {
          LaunchNumber ++ ;
          SaveScore();
          PlayerPrefs.Flush();
     }
}
