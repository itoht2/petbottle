using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PumpingButton : MonoBehaviour {
     bool push = false;
     public SpecData specData;
     public ScoreData scoreData;
     public float PumpMax;
     public float PumpCapacity;
     public float PumpPressure;
     public GameObject PumpAnimation;
     public GameObject Bubble;
     public BubbleController _bubbleController;
     private AudioSource BubbleSound;
     private AudioSource ExplosionSound;

     private float BottolePressureMax;
     private bool Broken;
     private Vector3 ScaleW;
     public GameObject ExplisionPrefab;  

     public GameObject Rocket;
     private RocketController rocketController;
     private bool Launched;

     public MainSwitchController mainSwitchController;     

     // Use this for initialization
     void Start()
     {
          PumpMax = specData.GetPumpMax();
          PumpCapacity = specData.GetPumpCapacity();
          PumpPressure = 0;
          Bubble.SetActive(true);
          AudioSource[] audioSources = GetComponents<AudioSource>();
          BubbleSound = audioSources[0];
          ExplosionSound = audioSources[1];
          BubbleSound.Stop();
          BottolePressureMax = specData.GetInnerPressureMax();

          rocketController = Rocket.GetComponent<RocketController>();

          Launched = false;

     }

     public void PushDown()
     {
          if (Broken || Launched)
          {
               return;
          }

          if (!mainSwitchController.GetMainSwitch())
          {
               return;
          }
          

          push = true;
         BubbleSound.Play();
     }

     public void PushUp()
     {
          push = false;
         BubbleSound.Stop();
     }

     void Update()
     {
          Launched = rocketController.GetLaunched();

          if (Broken || Launched)
          {
               PumpAnimation.GetComponent<Animator>().SetBool("PumpStart", false);

               _bubbleController.StopBubble();
               return;
          }

          if (push)
          {
               Pumping();
               PumpAnimation.GetComponent<Animator>().SetBool("PumpStart", true);

               if (PumpMax > PumpPressure)
               {
                    _bubbleController.StartBubble();
                   
               } else 
               {
                    _bubbleController.StopBubble();
                    
               }                    

          } else
          {
               PumpAnimation.GetComponent<Animator>().SetBool("PumpStart", false);
             
               _bubbleController.StopBubble();
          }

          if (BottolePressureMax < PumpPressure || Launched) //破裂
          {
               ExplosionSound.PlayOneShot(ExplosionSound.clip);
                 PumpPressure = 0;
               Broken = true;
               rocketController.Broken = true;

               Instantiate(ExplisionPrefab, Rocket.transform.position, Rocket.transform.rotation);              

               ScaleW.y = 0.0f;
               rocketController.Water.transform.localScale = ScaleW;

               Rocket.GetComponent<Rigidbody2D>().AddTorque(2.0f, ForceMode2D.Impulse);
                             
               scoreData.ScoreNow = -10.0f;  //破裂したらマイナスポイント
               scoreData.SaveScore();

               StartCoroutine("GoScore");
          }
     } 

     void Pumping()
     {
          if (PumpMax > PumpPressure)
          {
               PumpPressure += PumpCapacity;             
          }
          else
          {
               PumpPressure = PumpMax;
               BubbleSound.mute = true;

          }
          specData.PumpPressure = PumpPressure;
          specData.Recalculation();
     }

     IEnumerator GoScore()
     {
          yield return new WaitForSeconds(3.5f);
          //Debug.Log("GoScore");
          SceneManager.LoadScene("ScoreUpdate");
          yield return null;

     }
}
