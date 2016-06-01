using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RocketController : MonoBehaviour {

     Rigidbody2D RocketBody2D;
     public ScoreData ScoreData;
     public GameObject WaterJet;
     private AudioSource WaterJetSound;

     public GameObject[] SRBAJet;
     public GameObject[] SRBABody;
     public GameObject Rockt;
     private Rigidbody2D ScoreBody;

     public GameObject MainCamera;
     public GameObject MapCamera;

     public GameObject RocketHontai;
     private Rigidbody2D Rb2;

     public bool IsCanSat;
     public GameObject CanSat;
     private GameObject CanSatPrefab;
     private FixedJoint2D CanSatJoint;
     private string CanSatName;
     private bool IsEjected;
     public AudioClip CansatSound;

     private GameObject ParaPrefab;
     private HingeJoint2D ParaJoint;

     public GameObject NoseCorn;
     private FixedJoint2D NoseCornJoint;

     private float LancherForce;

     private float dx;
     private float dy;
   

     public float[] SRBAxPosition;
     public float thrustForce;
     public float SRBAthrustForce;
     public float thrustTime;
     public float SRBAthrustTime;
     private GameObject SRBAJetPrefab;
     private GameObject SRBABodyPrefab;
     public AudioClip SRBASound;

     private float SideThrustForce;
     private float SideThrustTime;
     private float SideThrustTimeMax;
     private GameObject SideThrustJetPrefab;
     public GameObject SideThrustJet;
     public GameObject SideThrustJetL;
     private Vector2 SideTrustR;
     private Vector2 SideTrustL;
     public ParticleSystem.EmissionModule SideTrustEmission;
     public ParticleSystem.EmissionModule SideTrustEmissionL;

     private bool BackPanelClosed;
     public GameObject BackPanel;

     public bool TopFlag;
     public Vector3 effectRotation;
     public bool Launched = false;
     public bool SRBALaunched = false;

     private float timeTemp;
     private float SRBAtimeTemp;
     private float startTime;
     private float SRBAstartTime;
     private float SRBAPositionFactor;
     private Vector3 pos;
     private Vector3 SRBAoffset;

     public float score;
     public SpecData specData;
     public int Stage;
     public int SRBANumber;


     public Text scoreLabel;
     public Text SpeedMeter;
     private bool Landed;

     private float SpeedMax;
     private Vector2 LastVelocity;
     private float MaxG;

     //private Vector2 center ;
     public GameObject Water;
     private float PumpMax ;
     public Text PumpMaxText;
     public bool Broken;

     public float AirResistancce;
     private float Cd;
     private float NoseCornCD;
     private float FinCD;
     private float CDFactor;
     private float DensityOfAir;
     private float ProjectedArea;
     

     void Awake ()
     {
          
     }

     // Use this for initialization
     void Start () {
          RocketBody2D = RocketHontai.GetComponent<Rigidbody2D>();
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();

          RocketBody2D.mass = specData.GetMass();
          ScoreBody = RocketBody2D;

          ScoreData.ScoreCoefficient = 1.0f;

          Stage = specData.GetMultistage();
          SRBANumber = specData.GetSRBANumber();

          LancherForce = specData.GetLauncherForce();

         SRBAxPosition = new float[SRBANumber + 1];
          GetSRBAxPosition(SRBANumber);
          SRBAPositionFactor = specData.GetSRBApositionFactor();
          SRBAoffset = specData.GetSRBAOffset();



          WaterJetSound = gameObject.GetComponent<AudioSource>();

         

         //center = new Vector2(0.0f, 2.0f);

         SideThrustForce = specData.GetSideThrusterForce();
          SideThrustTime = specData.GetSideThrusterTime();
          SideThrustTimeMax = SideThrustTime;

          PumpMax = specData.GetInnerPressureMax();
          PumpMaxText.text = PumpMax.ToString("N0");

          if (SideThrustTime != 0.0f)
          {
               specData.SideThrusterRate = 1.0f;
               SideThrustJetPrefab = (GameObject)Resources.Load("Prefabs/Effects/SideThrustParticle");

               SideTrustR = Vector2.right * -0.84f;
               SideTrustL = Vector2.right * 0.84f;

               SideThrustJet = (GameObject)Instantiate(SideThrustJetPrefab, Vector2.zero, Quaternion.Euler(0.0f, -90.0f, 0.0f));
               SideThrustJetL = (GameObject)Instantiate(SideThrustJetPrefab, Vector2.zero, Quaternion.Euler(0.0f, 90.0f, 0.0f));

               SideThrustJet.transform.parent = ScoreBody.transform;
               SideThrustJetL.transform.parent = ScoreBody.transform;

               SideThrustJet.name = "SideThrustJet";
               SideThrustJetL.name = "SideThrustJetL";

               SideThrustJet.transform.localPosition = SideTrustR;
               SideThrustJet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

               SideThrustJetL.transform.localPosition = SideTrustL;
               SideThrustJetL.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);


               SideTrustEmission = SideThrustJet.GetComponent<ParticleSystem>().emission;
               SideTrustEmission.enabled = false;
               SideTrustEmissionL = SideThrustJetL.GetComponent<ParticleSystem>().emission;
               SideTrustEmissionL.enabled = false;

          }
          else
          {
               specData.SideThrusterRate = 0.0f;
          }

       
          Cd = specData.GetCd();
          NoseCornCD = specData.GetNoseCornCD();
          FinCD = specData.GetFinCD();
          CDFactor = specData.GetCDFactor();
          DensityOfAir = specData.GetDensityOfAir();
          ProjectedArea = specData.GetDensityOfAir();

          StartCoroutine("ReCalcResistance");

          //Debug.Log(specData.GetPayLoadName().Length);
          //Debug.Log(IsCanSat);


          WaterJet.SetActive(false);
          TopFlag = false;
          BackPanelClosed = false;
          Landed = false;

          IsCanSat = !(specData.GetPayLoadName().Length == 0);

          if (IsCanSat)
          {
               // CanSat搭載
               CanSatName = specData.GetPayLoadName();
               CanSatPrefab = (GameObject)Resources.Load("Prefabs/" + CanSatName);

               CanSat = (GameObject)Instantiate(CanSatPrefab, new Vector3(0.0f, 2.08f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
               CanSat.name = "CanSat";


               CanSat.GetComponent<BoxCollider2D>().isTrigger = true;
               CanSatJoint = CanSat.GetComponent<FixedJoint2D>();
               CanSatJoint.connectedBody = RocketBody2D;
               CanSatJoint.enabled = true;

               IsEjected = false;
          }

          // SRBAのプレハブを取得
          SRBAJetPrefab = (GameObject)Resources.Load("Prefabs/Effects/SRBAJet");
          SRBABodyPrefab = (GameObject)Resources.Load("Prefabs/SRBA");

          for (int i = 0; i < SRBANumber; i++)
          {
               pos = new Vector3(SRBAxPosition[i] * SRBAPositionFactor, -1.12f, 0.0f);
               // インスタンス生成
               GameObject SRBAJetObject = (GameObject)Instantiate(SRBAJetPrefab, pos, Quaternion.Euler(90.0f, 180.0f, 0.0f));
               GameObject SRBABodyObject = (GameObject)Instantiate(SRBABodyPrefab, pos + SRBAoffset, Quaternion.Euler(0.0f, 0.0f, 0.0f));

               SRBAJetObject.tag = "SRBA";
               SRBABodyObject.tag = "SRBABody";

               SRBABodyObject.name = string.Format("{0}", i);

               //  SRBAJetObject.SetActive(false) ;
               // 作成したオブジェクトを子として登録
               SRBAJetObject.transform.parent = RocketHontai.transform;
               SRBABodyObject.transform.parent = RocketHontai.transform;
          }

          SRBAJet = GameObject.FindGameObjectsWithTag("SRBA");

          foreach (GameObject obs in SRBAJet)
          {
               obs.SetActive(false);
          }

          SRBABody = GameObject.FindGameObjectsWithTag("SRBABody");
          foreach (GameObject obs in SRBABody)
          {
               obs.SetActive(true);
          }

     }

     // Update is called once per frame

     void Update() {
	
          score = Mathf.Max(score, ScoreBody.transform.position.y);
          SpeedMax = Mathf.Max(SpeedMax, ScoreBody.velocity.y);
         
          scoreLabel.text = ScoreBody.transform.position.y.ToString("N2") ;
          SpeedMeter.text = ScoreBody.velocity.y.ToString("N1") ;

        


          if (score > RocketBody2D.transform.position.y + 2.0f) // 頂点に達したら(2m落ちたら)
          {
              if (!TopFlag)

               {  
                    ScoreData.CalcNewScore(score);
                    TopFlag = true;
                   
                    //RocketBody2D.centerOfMass = center;
                    StartCoroutine("Rotate");
                    ScoreData.ScoreNow = score;
                    ScoreData.CalcMaxDistance(score);
                    ScoreData.SaveScore();
               }

              if (ScoreBody.transform.position.y <= 1.0f && ScoreBody.velocity.y <=0.5f && !Landed)
               {
                   //Debug.Log("Stop");
                    StartCoroutine("GoScore");
                   
                    Landed = true;

               }              
               
          } 

     }
     

     public void Fire()
     {
          if (specData.GetPumpPressure() == 0.0f)
          {
               return;
          }

          if (Broken)
          {
               return;
          }

          if (Stage >= 1)
          {
               StartCoroutine("Launch");
               Stage = Stage - 1;
               Launched = true; 
          }

          if (!BackPanelClosed) // 戻るパネル隠して
          {
               StartCoroutine("BackPanelClose");
          }

          if (!SRBALaunched)
          {
               StartCoroutine("LaunchSRBA");
               SRBALaunched = true;
          }          
     }

     public void SideThruster(bool Right)  // サイドスラスト噴射（フィンによる制御も込み）
     {

          if (Broken)
          {
               return;
          }

          if (SideThrustTime > 0.0f) { 
               if (Right)

               {
                    ScoreBody.AddForce(ScoreBody.transform.right * SideThrustForce, ForceMode2D.Force);
                    SideThrustJet.transform.localPosition = SideTrustR;
               }
               else
               {
                    ScoreBody.AddForce(ScoreBody.transform.right * -SideThrustForce, ForceMode2D.Force);
                    SideThrustJet.transform.localPosition = SideTrustL;
               }               

               SideThrustTime = SideThrustTime - Time.deltaTime;
               specData.SideThrusterRate = (SideThrustTime / SideThrustTimeMax);

          } else
          {
               SideTrustEmission.enabled = false;
               SideTrustEmissionL.enabled = false;

          }


         
     }

     IEnumerator Rotate()
     {

          yield return new WaitForSeconds(0.5f);
   //       RocketBody2D.AddTorque(0.2f, ForceMode2D.Impulse);
          yield return null;
     }

     IEnumerator GoScore()
     {
          yield return new WaitForSeconds(5.0f);
          //Debug.Log("GoScore");
          SceneManager.LoadScene("ScoreUpdate");
          yield return null;

     }

     IEnumerator Launch()    
     {

           startTime = Time.time;

          specData.Recalculation();
          //Debug.Log(specData.GetMass());
          RocketBody2D.mass = specData.GetMass();
        
          timeTemp = 0.0f;
          thrustForce = specData.GetThrustForce();
          thrustTime = specData.GetBurningTime();

          RocketBody2D.gravityScale = specData.GetGravity() / 9.8f;

          ScoreData.AddLaunchNumber();
          WaterJet.SetActive(true);

          //  Debug.Log(startTime);
          Vector3 ScaleW = Water.transform.localScale;
          float posTemp = 0.0f;
          float posMax = ScaleW.y;

          WaterJetSound.PlayOneShot(WaterJetSound.clip);

          if (LancherForce > 0.0f)
          {
               //RocketBody2D.AddForce(RocketBody2D.transform.up * LancherForce, ForceMode2D.Impulse);
               StartCoroutine("LauncherAddForce");


               LancherForce = 0.0f;
          }

          while (thrustTime >= timeTemp) {
               timeTemp = Time.time - startTime;               
              
               // ロケット発射             
               
               RocketBody2D.AddForce(RocketBody2D.transform.up * thrustForce);

               

               posTemp = posMax * (thrustTime - timeTemp) / thrustTime ;
               ScaleW.y = posTemp;

               Water.transform.localScale = ScaleW;

                 yield return null; //          
                
          }

          // メインエンジン燃焼終了後
          WaterJet.SetActive(false);

          if (Stage >= 1) // 多段式でまだ残っていたら、燃料再充填
          {
               ScaleW.y = posMax;
               Water.transform.localScale = ScaleW;
          } else
          {
               ScaleW.y = 0.0f;
               Water.transform.localScale = ScaleW;
          }


     }

     IEnumerator LauncherAddForce()
     {
          for (int i = 0; i < 60; i++)
          {
               RocketBody2D.AddForce(RocketBody2D.transform.up * LancherForce, ForceMode2D.Force);

               yield return null;
               //Debug.Log("LaunchForce");
          }
     }

     IEnumerator LaunchSRBA()
     {

          SRBAstartTime = Time.time;

          specData.Recalculation();
          SRBAtimeTemp = 0.0f;
          SRBAthrustForce = specData.GetSRBAThrustForce();
          SRBAthrustTime = specData.GetSRBABurningTime();
          GetComponent<AudioSource>().PlayOneShot(SRBASound);
          foreach (GameObject obs in SRBAJet)
               {
                    obs.SetActive(true);
               }

          //  Debug.Log(startTime);

          while (SRBAthrustTime >= SRBAtimeTemp)
          {
               SRBAtimeTemp = Time.time - SRBAstartTime;
                // SRBA発射
               RocketBody2D.AddForce(RocketBody2D.transform.up * SRBAthrustForce * SRBANumber);
               
               yield return null; //                  
          }

          // SEBA燃焼終了後
          foreach (GameObject obs in SRBAJet) // ジェット噴射終了
          {
               obs.SetActive(false);
          }

          yield return new WaitForSeconds(0.3f);
       
          SRBAjettison();

     }

     public void SRBAjettison()
     {
          foreach (GameObject obs in SRBABody)
          {
               obs.transform.parent = null;
               Rb2 = obs.GetComponent<Rigidbody2D>();
               Rb2.isKinematic = false;
               dx = SRBAxPosition[int.Parse(obs.name)] * 0.0002f;
               dy = RocketBody2D.velocity.y * 0.00007f;

               Rb2.AddForce(new Vector2(dx, dy), ForceMode2D.Impulse);
               Rb2.AddTorque(-dx * 2000.0f, ForceMode2D.Impulse);

               // Rb2.velocity = RocketBody2D.velocity;
          }

          StartCoroutine("SRBADestroy");
     }

     IEnumerator SRBADestroy()
     {
          yield return new WaitForSeconds(2.0f);

          foreach (GameObject obs in SRBABody)
          {
               Destroy(obs, 1.0f);
          }
          foreach (GameObject obs in SRBAJet)
          {
               Destroy(obs, 1.0f);
          }
     }


     public void PayLoadEject()
     {
          if (Broken)
          {
               return;
          }

          if (IsCanSat && !(IsEjected))
          {
               IsEjected = true;
               StartCoroutine("EjectCansat");
               Stage = 0;

          }
         
     }

     IEnumerator EjectCansat()
     {         

          CanSatJoint = CanSat.GetComponent<FixedJoint2D>();
          NoseCornJoint = NoseCorn.GetComponent<FixedJoint2D>();

          yield return new WaitForSeconds(0.3f);
          //CanSat.GetComponent<BoxCollider2D>().enabled = true;
          //CanSat.GetComponent<BoxCollider2D>().isTrigger = false;

          CanSat.GetComponent<BoxCollider2D>().isTrigger = false;

          NoseCornJoint.enabled = false;
          NoseCorn.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 0.01f), ForceMode2D.Impulse);
          NoseCorn.GetComponent<Rigidbody2D>().AddTorque(0.001f, ForceMode2D.Impulse);

          yield return new WaitForSeconds(0.3f);

          GetComponent<AudioSource>().PlayOneShot(CansatSound);

          CanSatJoint.enabled = false;
          CanSat.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.1f), ForceMode2D.Impulse);
          ScoreBody = CanSat.GetComponent<Rigidbody2D>();
          SideThrustJet.transform.parent = ScoreBody.transform;
          SideThrustJetL.transform.parent = ScoreBody.transform;

          SideTrustR = Vector2.right * -2.0f;
          SideTrustL = Vector2.right * 2.0f;

          SideThrustJet.transform.localPosition = SideTrustR;
          SideThrustJet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

          SideThrustJetL.transform.localPosition = SideTrustL;
          SideThrustJetL.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

          MainCamera.GetComponent<FollowCamera>().objTarget = CanSat;
          MapCamera.GetComponent<FollowCamera>().objTarget = CanSat;

          ParaPrefab = (GameObject)Resources.Load("Prefabs/Para");
          GameObject ParaObject = (GameObject)Instantiate(ParaPrefab);

          ParaObject.name = "Para";
          ParaObject.transform.position = CanSat.transform.position;
          yield return new WaitForSeconds(0.3f);
          ParaJoint = ParaObject.GetComponent<HingeJoint2D>();
          ParaJoint.connectedBody = CanSat.GetComponent<Rigidbody2D>();
          ParaJoint.anchor = new Vector2(0.0f, -4.5f);
          ParaJoint.connectedAnchor = new Vector2(0.0f, 4.0f);           

          yield return null;

         
     }

     IEnumerator BackPanelClose()  // 戻るパネルを隠す
     {
          BackPanelClosed = true;
          yield return new WaitForSeconds(1.0f);
          for (int i = 0; i < 130; i=i+3)
          {
               BackPanel.GetComponent<RectTransform>().anchoredPosition = new Vector3(5.0f, (float) i, 0.0f); ;
               yield return null;
          }
     }

     IEnumerator ReCalcResistance()
     {
          while (ScoreBody != null)
          {
               AirResistancce = (Cd + NoseCornCD + FinCD) * CDFactor * DensityOfAir * ProjectedArea * ScoreBody.velocity.y * ScoreBody.velocity.y / 2;
               ScoreBody.AddForce(-AirResistancce * ScoreBody.velocity / 500);

               //Debug.Log(ScoreBody.name);
               yield return new WaitForSeconds(0.2f);
              
          }
     }

     public bool GetLaunched()
     {
          return Launched;
     }

     public float GetSideThrustTime()
     {
          return SideThrustTime;
     }

     public void GetSRBAxPosition(int Number)     
          {
          switch (Number)
          {
               
               case 2:
                    SRBAxPosition[0] = -1.0f;
                    SRBAxPosition[1] =  1.0f;
                    return;
               case 4:
                    SRBAxPosition[0] = -1.0f;
                    SRBAxPosition[1] = 0.0f;
                    SRBAxPosition[2] = 1.0f;
                    return;
               case 6:
                    SRBAxPosition[0] = -1.0f;
                    SRBAxPosition[1] = -0.5f;
                    SRBAxPosition[2] = 0.5f;
                    SRBAxPosition[3] = 1.0f;
                    return;
               case 8:
                    SRBAxPosition[0] = -1.0f;
                    SRBAxPosition[1] = -0.7f;
                    SRBAxPosition[2] = 0.0f;
                    SRBAxPosition[3] = 0.7f;
                    SRBAxPosition[4] = 1.0f;
                    return;
               default:
                    SRBAxPosition[0] = 0.0f;
                    return;

          }         

     }
     
}
