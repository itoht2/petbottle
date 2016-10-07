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
          this.GetComponent<Transform>().position = new Vector3(0.0f, MaxHight, 0);
          sound01 = GetComponent<AudioSource>();
          SoundPlayed = false;
          Launched = false;

          MaxX = 20.0f;
          MinX = -20.0f;


     }
	
	// Update is called once per frame
	void Update () {
          if (Rocket.GetScoreBodyX() > MaxX)
          {

          }
          if (Rocket.GetScoreBodyX() < MinX)
          {

          }


     }

     void OnTriggerEnter2D(Collider2D collision)
     {

          Launched = Rocket.GetLaunched();

          if (!SoundPlayed && Launched)
          {
               sound01.PlayOneShot(sound01.clip);
               SoundPlayed = true;
          }

     }

     }
