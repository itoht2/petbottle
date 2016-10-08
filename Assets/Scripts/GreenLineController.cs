using UnityEngine;
using System.Collections;

public class GreenLineController : MonoBehaviour {

     public ScoreData scoreData;
     public RocketController Rocket;
     private float MaxHight;
     private AudioSource sound01;
     private bool SoundPlayed;
     private bool Launched ;
     private float MaxX;
     private float MinX;

     // Use this for initialization
     void Start () {

          scoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();

          MaxHight = scoreData.GetMaxDistance();
          //Debug.Log("maxDistance" + MaxHight);
          GetComponent<Transform>().position = new Vector3(0.0f, MaxHight, 0);
          sound01 = GetComponent<AudioSource>();
          SoundPlayed = false;
          Launched = false;

          MaxX = 10.0f;
          MinX = -10.0f;


     }
	
 	// Update is called once per frame
	void Update () {

          if (Rocket.GetScoreBodyY() > MaxHight)
          {
               HiScoreHit();
          }

          if (Rocket.GetScoreBodyX() > MaxX )
          {
               //Debug.Log(Rocket.GetScoreBodyX());
               Vector2 posTemp = transform.position;
               posTemp.x += 10;
               transform.position = posTemp;
               MaxX += 10;
               MinX -= 10;
          }
          if (Rocket.GetScoreBodyX() < MinX)
          {
               Vector2 posTemp = transform.position;
               posTemp.x -= 10;
               transform.position = posTemp;
               MaxX -= 10;
               MinX += 10;
          }


     }

     //void OnTriggerEnter2D(Collider2D collision)
     //{

     //     Launched = Rocket.GetLaunched();

     //     if (!SoundPlayed && Launched)
     //     {
     //          sound01.PlayOneShot(sound01.clip);
     //          SoundPlayed = true;
     //          int Takasa = (int)transform.position.y;
     //          int keta = Mathf.Max(GetDigit(Takasa) - 2, 0);
     //          Takasa = (int)(Mathf.Round(Takasa / Mathf.Pow(10, keta)) * Mathf.Pow(10, keta));
     //          scoreData.HiScoreBonus = (Takasa / 5 );


     //     }

     //}

     void HiScoreHit()
     {

          Launched = Rocket.GetLaunched();

          if (!SoundPlayed && Launched)
          {
               sound01.PlayOneShot(sound01.clip);
               SoundPlayed = true;
               int Takasa = (int)transform.position.y;
               int keta = Mathf.Max(GetDigit(Takasa) - 2, 0);
               Takasa = (int)(Mathf.Round(Takasa / Mathf.Pow(10, keta)) * Mathf.Pow(10, keta));
               scoreData.HiScoreBonus = (Takasa / 5);
          }

     }


     public static int GetDigit(int num)
     {
          return (num == 0) ? 1 : (int)Mathf.Log10(num) + 1;
     }

}
