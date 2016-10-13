using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RocketController : MonoBehaviour {

     Rigidbody2D RocketBody2D;
     public ScoreData ScoreData;
     public GameObject WaterJet;
     private AudioSource WaterJetSound;

     public GameObject ground;

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
     public AudioClip[] HimawariSound;

     private GameObject ParaPrefab;
     private HingeJoint2D ParaJoint;
     private FrictionJoint2D ParaJointFriction;
     private GameObject ParaObject;

     public GameObject NoseCorn;
     private FixedJoint2D NoseCornJoint;

     private float LancherForce;

     private float dx;
     private float dy;
     private int Ccount;

     private MainSwitchController mainSwitchController;
     private float TemperatureOfGraund = 20.0f;

     private NoseCornFolder sRBAFolder;   

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
     public GameObject SideThrustJetU;
     private Vector2 SideThrustR;
     private Vector2 SideThrustL;
     private Vector2 SideThrustU;
     public ParticleSystem.EmissionModule SideThrustEmission;
     public ParticleSystem.EmissionModule SideThrustEmissionL;
     public ParticleSystem.EmissionModule SideThrustEmissionU;

     private bool BackPanelClosed;
     public GameObject BackPanel;

     public GameObject CheckButton;

     private float XmaxR;
     private float XmaxL;
     private GameObject WoodsPrefab1;
     private GameObject WoodsPrefab2;

     public OnStart onStart;

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

     public float oldMaxDistance;

     private float Stability;

     public Text scoreLabel;
     public Text SpeedMeter;
     private bool Landed;

     private float SpeedMax;
     private Vector2 LastVelocity;
     private float MaxG;
     public bool CheckButtonOpend;

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

     public float[] tScale;
     public int tRank;

     public GameObject mLabel;
     public GameObject kmLabel; 

     void Awake ()
     {
          
     }

     // Use this for initialization
     void Start () {
          RocketBody2D = RocketHontai.GetComponent<Rigidbody2D>();
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          ScoreData = GameObject.Find("ScoreData").GetComponent<ScoreData>();

          RocketBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;  // 回転させない

          onStart = GameObject.Find("OnStart").GetComponent<OnStart>();


          RocketBody2D.mass = specData.GetMass();
          ScoreBody = RocketBody2D;

          ScoreData.ScoreCoefficient = 1.0f;

          specData.SpeedMax = 0.0f;

          Stage = specData.GetMultistage();
          SRBANumber = specData.GetSRBANumber();

          LancherForce = specData.GetLauncherForce();

         SRBAxPosition = new float[SRBANumber + 1];
          GetSRBAxPosition(SRBANumber);
          SRBAPositionFactor = specData.GetSRBApositionFactor();
          SRBAoffset = specData.GetSRBAOffset();

          Stability = specData.GetStability();

          WaterJetSound = gameObject.GetComponent<AudioSource>();

          tScale = new float [] { 1.0f, 2.7f, 7.9f ,120f};
          tRank =  0;

         //center = new Vector2(0.0f, 2.0f);

         SideThrustForce = specData.GetSideThrusterForce();
          SideThrustTime = specData.GetSideThrusterTime();
          SideThrustTimeMax = SideThrustTime;

          PumpMax = specData.GetInnerPressureMax();
    
          PumpMaxText.text = PumpMax.ToString("N0");

          oldMaxDistance = ScoreData.GetMaxDistance(); 

          XmaxL = -50.0f;
          XmaxR = 50.0f;

          WoodsPrefab1 = (GameObject)Resources.Load("Prefabs/Woods1");
          WoodsPrefab2 = (GameObject)Resources.Load("Prefabs/Woods2");

          for (int i = -50; i <= 50; i=i+50 ) // まずは森を3つ書く
          {
               DrowWoods(i);

          }
          
          if (SideThrustTime != 0.0f)
          {
               specData.SideThrusterRate = 1.0f;
               SideThrustJetPrefab = (GameObject)Resources.Load("Prefabs/Effects/SideThrustParticle");

               SideThrustR = Vector2.right * -0.84f;
               SideThrustL = Vector2.right * 0.84f;
               SideThrustU = Vector2.up * 0.84f;

               SideThrustJet = (GameObject)Instantiate(SideThrustJetPrefab, Vector2.zero, Quaternion.Euler(0.0f, -90.0f, 0.0f));
               SideThrustJetL = (GameObject)Instantiate(SideThrustJetPrefab, Vector2.zero, Quaternion.Euler(0.0f, 90.0f, 0.0f));
               SideThrustJetU = (GameObject)Instantiate(SideThrustJetPrefab, Vector2.zero, Quaternion.Euler(90.0f, 0.0f, 0.0f));

               SideThrustJet.transform.parent = ScoreBody.transform;
               SideThrustJetL.transform.parent = ScoreBody.transform;
               SideThrustJetU.transform.parent = ScoreBody.transform;

               SideThrustJet.name = "SideThrustJet";
               SideThrustJetL.name = "SideThrustJetL";
               SideThrustJetU.name = "SideThrustJetU";


               SideThrustJet.transform.localPosition = SideThrustR;
               SideThrustJet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

               SideThrustJetL.transform.localPosition = SideThrustL;
               SideThrustJetL.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

               SideThrustJetU.transform.localPosition = SideThrustU;
               SideThrustJetU.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);


               SideThrustEmission = SideThrustJet.GetComponent<ParticleSystem>().emission;
               SideThrustEmission.enabled = false;
               SideThrustEmissionL = SideThrustJetL.GetComponent<ParticleSystem>().emission;
               SideThrustEmissionL.enabled = false;
               SideThrustEmissionU = SideThrustJetU.GetComponent<ParticleSystem>().emission;
               SideThrustEmissionU.enabled = false;

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

          mainSwitchController = GameObject.Find("MainSwitch").GetComponent<MainSwitchController>();

          sRBAFolder = GameObject.Find("SRBAFolder").GetComponent<NoseCornFolder>();



          WaterJet.SetActive(false);
          TopFlag = false;
          BackPanelClosed = false;
          CheckButtonOpend = false;
          Landed = false;

          IsCanSat = !(specData.GetPayLoadName().Length == 0);

          if (IsCanSat)
          {
               // CanSat搭載
               CanSatName = specData.GetPayLoadName();
               CanSatPrefab = (GameObject)Resources.Load("Prefabs/" + CanSatName);
               //Debug.Log(CanSatName);

               CanSat = (GameObject)Instantiate(CanSatPrefab, new Vector3(0.0f, 2.08f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
               CanSat.name = "CanSat";

               CanSat.GetComponent<SpriteRenderer>().enabled = false;

               //CanSat.SetActive (false);


               if (CanSat.GetComponent<BoxCollider2D>())
               {
                    CanSat.GetComponent<BoxCollider2D>().isTrigger = true;
               }

               if (CanSat.GetComponent<CircleCollider2D>())
               {
                    CanSat.GetComponent<CircleCollider2D>().isTrigger = true;
               }



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

               SpriteRenderer SRBASprite = SRBABodyObject.GetComponent<SpriteRenderer>();

               SRBASprite.sprite = sRBAFolder.GetImage(sRBAFolder.GetNowUsed());
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

          float NowAltitude = ScoreBody.transform.position.y * tScale[tRank];
          score = Mathf.Max(score, NowAltitude);
          //Debug.Log(score);
          SpeedMax = Mathf.Max(SpeedMax, ScoreBody.velocity.y);

          if (NowAltitude <= 2000.0f)
          {    //ｍ単位
              
               if (mLabel.activeSelf == false && mainSwitchController.GetMainSwitch() == true)
               {
                    mLabel.SetActive(true);
                    kmLabel.SetActive(false);
               }

               scoreLabel.text = NowAltitude.ToString("N2") ;
          } else
          {    //ｋｍ単位
               float altitudeTemp = NowAltitude / 1000;
               scoreLabel.text = altitudeTemp.ToString("N2");
               if (kmLabel.activeSelf == false && mainSwitchController.GetMainSwitch() == true)
               {
                    kmLabel.SetActive(true);
                    mLabel.SetActive(false);
               }
          }
          

          SpeedMeter.text = ScoreBody.velocity.y.ToString("N1") ;

          specData.Speed = ScoreBody.velocity.y;
          specData.SpeedMax = SpeedMax;
          specData.Altitude = ScoreBody.transform.position.y;

          if (Launched && !TopFlag)
          {               
               //Debug.Log(Ccount);
               Ccount++;

               if (Ccount >= 10)
               {
                    RocketBody2D.MoveRotation(Random.Range(-Stability* 10 * Mathf.Clamp(ScoreBody.velocity.y / 50 , 0.0f, 2.0f), Stability * 10 * Mathf.Clamp(ScoreBody.velocity.y / 50, 0.0f, 2.0f)));  //　ブルブルフラフラ
                    //Debug.Log(ScoreBody.velocity.y / 50);
                    Ccount = 0;
               }
          }

         if (ScoreBody.position.x >= XmaxR)
          {
               XmaxR = XmaxR + 50;
               DrowWoods((int)XmaxR);
               onStart.Star(ScoreBody.position.y / 2 , XmaxR);
          }
          if (ScoreBody.position.x <= XmaxL)
          {
               XmaxL = XmaxL - 50;
               DrowWoods((int)XmaxL);
               onStart.Star(ScoreBody.position.y / 2 , XmaxL);
          }

          if (Mathf.Abs(ScoreBody.position.x - ground.transform.position.x) > 40)
          {
               ground.transform.position = new Vector2 (ScoreBody.position.x, ground.transform.position.y);
          }


          if (score > NowAltitude + 2.0f) // 頂点に達したら(2m落ちたら)
          {
              if (!TopFlag)
               {  
                    //ScoreData.CalcNewScore(score);
                    TopFlag = true;
                    RocketBody2D.constraints = RigidbodyConstraints2D.None ;  // 回転させる
                    

                    //RocketBody2D.centerOfMass = center;
                    StartCoroutine("Rotate");
                    //ScoreData.ScoreNow = score;
                    //ScoreData.CalcMaxDistance(score);
                    //ScoreData.SaveScore();

                    //StartCoroutine("CheckButtonOpen");

               }

               //if (ScoreBody.transform.position.y <= 1.0f && ScoreBody.velocity.y <=0.5f && !Landed) {
               // 地面に着いてｎ秒で結果へ行く　n=10
               if (ScoreBody.velocity.y <= 0.5f && Launched && ScoreBody.transform.position.y <= 2.0f && !Landed)
               {
                    //Debug.Log("Landed");

                    Landed = true;

                    StartCoroutine(GoScore(10.0f));
                    //transform.FindChild("SideFin").GetComponent<PolygonCollider2D>().enabled = true;


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
               
          }

          if (!BackPanelClosed ) // 戻るパネル隠して
          {
               StartCoroutine("BackPanelClose");
          }

          if (!CheckButtonOpend)
          {
               StartCoroutine("CheckButtonOpen");
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
                    SideThrustJet.transform.localPosition = SideThrustR;
               }
               else
               {
                    ScoreBody.AddForce(ScoreBody.transform.right * -SideThrustForce, ForceMode2D.Force);
                    SideThrustJet.transform.localPosition = SideThrustL;
               }               

               SideThrustTime = SideThrustTime - Time.deltaTime;
               specData.SideThrusterRate = (SideThrustTime / SideThrustTimeMax);

          } else
          {
               SideThrustEmission.enabled = false;
               SideThrustEmissionL.enabled = false;
               SideThrustEmissionU.enabled = false;

          }


         
     }

     public void UpThruster()  // 上向きスラスト噴射
     {

          if (Broken)
          {
               return;
          }

          if (SideThrustTime > 0.0f)
          {
               
               ScoreBody.AddForce(ScoreBody.transform.up * SideThrustForce, ForceMode2D.Force);
               SideThrustJet.transform.localPosition = SideThrustU;              
              

               SideThrustTime = SideThrustTime - Time.deltaTime;
               specData.SideThrusterRate = (SideThrustTime / SideThrustTimeMax);

          }
          else
          {
               SideThrustEmission.enabled = false;
               SideThrustEmissionL.enabled = false;
               SideThrustEmissionU.enabled = false;



          }



     }

     IEnumerator Rotate()
     {

          yield return new WaitForSeconds(0.2f);
          RocketBody2D.AddTorque(Random.Range(-Stability * 1.5f - 1f,Stability *1.5f +1f), ForceMode2D.Impulse);
          yield return null;
     }

     IEnumerator GoScore(float tranjisionTime)
     {
          //ScoreData.CalcNewScore(score);
          //ScoreData.ScoreNow = score;
          //ScoreData.CalcMaxDistance(score);
          //ScoreData.SaveScore();

          ScoreDataStore();
          //Debug.Log(tranjisionTime);
          //Time.timeScale = 1.0f;
          yield return new WaitForSeconds(tranjisionTime);
          //Debug.Log(Mathf.Max(5.0f, SideThrustTime));
          SceneManager.LoadScene("ScoreUpdate");
          yield return null;

     }

     public void ScoreDataStore()
     {
          ScoreData.CalcNewScore(score);
          ScoreData.ScoreNow = score;
          ScoreData.CalcMaxDistance(score);
          //ScoreData.SaveScore();
          //Debug.Log(score);
     }

     IEnumerator Launch()    
     {
          if (SystemInfo.supportsVibration)
          {
               Handheld.Vibrate();
          }
               
           startTime = Time.time;
          Launched = true;
          if(specData.GetStability() != 0) {  
               RocketBody2D.constraints = RigidbodyConstraints2D.None;  // 回転させる
          }

          specData.Recalculation();
          //Debug.Log(specData.GetMass());
          RocketBody2D.mass = specData.GetMass();

          //float totlThrustFource = specData.GetThrustForce() * specData.GetBurningTime() + specData.GetSRBANumber() * specData.GetSRBAThrustForce() * specData.GetSRBABurningTime() ;

          //Debug.Log("orce()"+ specData.GetBurningTime());

          //Debug.Log(totlThrustFource); 

          //if (totlThrustFource <= 200f)
          //{
          //     tRank = 0;
          //} else if (totlThrustFource <= 400f)
          //{
          //     tRank = 1;         
          //} else if (totlThrustFource <= 900f)
          //{
          //     tRank = 2;
          //} else {
          //     tRank = 3;
          //}

          //Time.timeScale = tRank +1;

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

          if (mainSwitchController.GetMainSwitch() == false)
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
          ScoreBody = CanSat.GetComponent<Rigidbody2D>();
          yield return new WaitForSeconds(0.3f);

          //CanSat.SetActive(true);

          int Takasa = (int)ScoreBody.position.y;
          int keta = Mathf.Max(GetDigit(Takasa) - 2, 0);
          Takasa = (int)(Mathf.Round(Takasa / Mathf.Pow(10, keta)) * Mathf.Pow(10, keta));
          ScoreData.EjectBonus = (Takasa / 10);


          CanSatJoint = CanSat.GetComponent<FixedJoint2D>();
          NoseCornJoint = NoseCorn.GetComponent<FixedJoint2D>();
          

          //CanSat.transform.FindChild("Collider").gameObject.SetActive(false);

          if (CanSat.GetComponent<BoxCollider2D>())
          {
               CanSat.GetComponent<BoxCollider2D>().isTrigger = false;
          }

          if (CanSat.GetComponent<CircleCollider2D>())
          {
               CanSat.GetComponent<CircleCollider2D>().isTrigger = false;
          }

          NoseCornJoint.enabled = false;
          NoseCorn.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 0.05f), ForceMode2D.Impulse);
          NoseCorn.GetComponent<Rigidbody2D>().AddTorque(0.002f, ForceMode2D.Impulse);

          //ScoreBody = CanSat.GetComponent<Rigidbody2D>();

          yield return new WaitForSeconds(0.3f);

          

          if (specData.GetPayLoadName() == "moe3")
          {
               int RndSoundID = Random.Range(0, HimawariSound.Length);
              
               GetComponent<AudioSource>().PlayOneShot(HimawariSound[RndSoundID]);
               //Debug.Log(RndSoundID);


          } else
          {
               GetComponent<AudioSource>().PlayOneShot(CansatSound);
          }
          

          CanSatJoint.enabled = false;
          CanSat.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.05f), ForceMode2D.Impulse);
          

          CanSat.GetComponent<SpriteRenderer>().enabled = true;

          //if (specData.GetRotateFix() == true) // サイドスラストが2N以上の場合は回転抑制 →缶サット側のプレファブで対応
          //{
          //     CanSat.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
          //}

          if (specData.GetSideThrusterTime() > 0.0f)
          {

               SideThrustJet.transform.parent = ScoreBody.transform;
               SideThrustJetL.transform.parent = ScoreBody.transform;
               SideThrustJetU.transform.parent = ScoreBody.transform;

               SideThrustR = Vector2.right * -2.0f;
               SideThrustL = Vector2.right * 2.0f;
               SideThrustU = Vector2.down * 3.3f;

               SideThrustJet.transform.localPosition = SideThrustR;
               SideThrustJet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

               SideThrustJetL.transform.localPosition = SideThrustL;
               SideThrustJetL.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

               SideThrustJetU.transform.localPosition = SideThrustU;
               SideThrustJetU.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
          }

          MainCamera.GetComponent<FollowCamera>().objTarget = CanSat;
          MapCamera.GetComponent<FollowCameraForMapcamera>().objTarget = CanSat;

          ParaPrefab = (GameObject)Resources.Load("Prefabs/Para");
          ParaObject = Instantiate(ParaPrefab);

          ParaObject.name = "Para";
          ParaObject.transform.position = CanSat.transform.position;
          yield return new WaitForSeconds(0.5f);

          ParaJoint = ParaObject.GetComponent<HingeJoint2D>();
          ParaJoint.connectedBody = CanSat.GetComponent<Rigidbody2D>();
          ParaJoint.anchor = new Vector2(0.0f, -4.5f);
          ParaJoint.connectedAnchor = new Vector2(0.0f, 4.0f);

          ParaJointFriction = ParaObject.GetComponent<FrictionJoint2D>();
          ParaJointFriction.connectedBody = CanSat.GetComponent<Rigidbody2D>();
          ParaJointFriction.maxTorque = 0.1f;
                  

         
          //Debug.Log(Takasa);

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

     IEnumerator CheckButtonOpen()  // チェックパネルを出す
     {
          CheckButtonOpend = true;
          yield return new WaitForSeconds(5.0f);
          for (int i = 0; i < 65; i = i +2)
          {
              CheckButton.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)i ,471f , 0.0f); ;
               yield return null;
          }
     }

     IEnumerator ReCalcResistance()
     {
          while (ScoreBody != null)
          {
               float TempAltitude = TemperatureOfGraund;

               if (ScoreBody.transform.position.y <= 11000.0f)
               {
                    TempAltitude = TemperatureOfGraund - 6.5f * ScoreBody.transform.position.y / 1000;

               } else if (ScoreBody.transform.position.y <= 20000)
               {
                    TempAltitude = TemperatureOfGraund - 6.5f * 11.0f;
               } else if (ScoreBody.transform.position.y <= 50000)
               {
                    TempAltitude = TemperatureOfGraund - 6.5f * 11.0f + ScoreBody.transform.position.y / 1000;
               }
               else if (ScoreBody.transform.position.y <= 90000)
               {
                    TempAltitude = TemperatureOfGraund - 1.875f * ScoreBody.transform.position.y / 1000 + 68.75f;
               } else
               {
                    TempAltitude = TemperatureOfGraund + 3.0f * ScoreBody.transform.position.y /1000 - 380.0f;
               }

               //Debug.Log("TempAltitude:"+TempAltitude);
               specData.Temperature = TempAltitude;

               float AtmospherPresuure = (1013.0f * Mathf.Pow(1.0f - (0.0065f * ScoreBody.transform.position.y / (TempAltitude + 273.15f)) , 5.258f)) /10;

               if (float.IsNaN(AtmospherPresuure))
               {
                    AtmospherPresuure = 0.01f;
               }

               if(AtmospherPresuure <= 0.01f )
               {
                    AtmospherPresuure = 0.01f;
               }
               //Debug.Log("Press:" + AtmospherPresuure + "Hight:" + ScoreBody.transform.position.y + "Temp:"+ TempAltitude);
               specData.AtmospherPresuure = AtmospherPresuure;

               DensityOfAir = AtmospherPresuure * 10 / (specData.GetGasConstant() * (TempAltitude + 273.15f));

               specData.DensityOfAir = DensityOfAir;
               //Debug.Log("DensityOfAir:" + DensityOfAir);

               AirResistancce = (Cd + NoseCornCD + FinCD) * CDFactor * DensityOfAir * ProjectedArea * Mathf.Pow(Mathf.Abs(ScoreBody.velocity.y) , 2.2f) / 2.0f ;
               //ScoreBody.AddForce(-AirResistancce * ScoreBody.velocity / 500);
              
               if (AirResistancce <= 10000 && ScoreBody.transform.position.y > 1000.0f) // 空気抵抗をなくさい
               {
                    AirResistancce = 10000.0f;
               }
               //Debug.Log("AirReg:" + AirResistancce);

               if (specData.GetSpeed() >= 0.0f )
               {
                    ScoreBody.AddForce(-AirResistancce * new Vector2(0.0f, 1.0f) / 100.0f);
               } 

               if (ParaObject != null)
               {
                    ParaObject.GetComponent<Rigidbody2D>().drag = 5.0f *  Mathf.Pow(DensityOfAir,4) * 0.482f ;
               }


               float TrueGravity = 9.80665f * Mathf.Pow((6356.766f / (6356.766f + ScoreBody.transform.position.y / 1000.0f)),2);
               //Debug.Log(TrueGravity);

               ScoreBody.gravityScale = TrueGravity / 9.80665f;

               //Debug.Log(TrueGravity);
               //yield return new WaitForSeconds(0.2f);
               yield return null;

          }
     }

     private void DrowWoods (int i) //森を書く
     {
          if (Random.Range(0, 2) == 1)
          {
               GameObject Woods = (GameObject)Instantiate(WoodsPrefab1, new Vector3(i, 2.8f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
               Woods.transform.parent = GameObject.Find("WoodsFolder").GetComponent<Transform>();
          }
          else
          {
               GameObject Woods = (GameObject)Instantiate(WoodsPrefab2, new Vector3(i, 2.8f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
               Woods.transform.parent = GameObject.Find("WoodsFolder").GetComponent<Transform>();
          }

     }

     public bool GetLaunched()
     {
          return Launched;
     }

     public float GetScoreBodyX()
     {
          return ScoreBody.position.x;
     }

     public float GetScoreBodyY()
     {
          return ScoreBody.position.y;
     }


     public float GetSideThrustTime()
     {
          return SideThrustTime;
     }

     public float GetSideThrustForce()
     {
          return SideThrustForce;
     }

     public static int GetDigit(int num)
     {
          return (num == 0) ? 1 : (int)Mathf.Log10(num) + 1;
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
