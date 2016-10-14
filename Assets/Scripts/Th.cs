using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Th : MonoBehaviour {

     public GameObject Rockt2D;
     RocketController rocketController;
     private ParticleSystem.EmissionModule SideTrustEmissionL;
     //private GameObject SideThrustJet;
     bool push = false;
     public bool Right;
     public AudioClip audioClip;
     public AudioClip Hidari;
     AudioSource audioSource;
     public MainSwitchController mainSwitchController;
     private SpecData specData;
     public Image Ing;


     // Use this for initialization
     void Start()
     {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();

          if (specData.GetSideThrusterTime() != 0.0f)
          {
               StartCoroutine("Startdelay");
          }
       
          audioSource = gameObject.GetComponent<AudioSource>();
          audioSource.clip = audioClip;
          Ing = GameObject.Find("ThrustimageL").GetComponent<Image>();
     }

     public void PushDown()
     {
          if (specData.GetSideThrusterTime() == 0.0f)
          {
               return;
          }
          float tTime = rocketController.GetSideThrustTime();
          //Debug.Log(tTime);
          if (!mainSwitchController.GetMainSwitch())
          {
               return;
          }
          if (tTime > 0.0)
          {
               push = true;
               SideTrustEmissionL.enabled = true;
               Ing.enabled = true;

               if(specData.GetPayLoadName() == "moe3")
                    {
                    audioSource.PlayOneShot(Hidari);
               } else {
                    audioSource.PlayOneShot(audioClip);
               }
               
          }
     }

     public void PushUp()
     {
          push = false;
          SideTrustEmissionL.enabled = false;
          Ing.enabled = false;
          audioSource.Stop();
     }

     void Update()
     {
          if (push)
          {
              
               rocketController.SideThruster(Right);

          }
     }

     private IEnumerator Startdelay()
     {
          yield return new WaitForSeconds(2.0f);
          rocketController = Rockt2D.GetComponent<RocketController>();
          SideTrustEmissionL = GameObject.Find("SideThrustJetL").GetComponent<ParticleSystem>().emission;
          Right = false;
     }

}
