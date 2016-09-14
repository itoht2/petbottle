using UnityEngine;
using System.Collections;

public class ThrustButton : MonoBehaviour {

     public GameObject Rockt2D;
     RocketController rocketController;
     private ParticleSystem.EmissionModule SideTrustEmission;
     //private GameObject SideThrustJet;
     bool push = false;     
     public bool Right;
     public AudioClip audioClip;
     AudioSource audioSource;
     public MainSwitchController mainSwitchController;
     private SpecData specData;

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
     }

     public void PushDown()
     {
          float tTime = rocketController.GetSideThrustTime();
          //Debug.Log(tTime);

          if (!mainSwitchController.GetMainSwitch())
          {
               return;
          }
          if (tTime > 0.0)
          {
               push = true;
               SideTrustEmission.enabled = true;
               audioSource.PlayOneShot(audioClip);
          }
     }

     public void PushUp()
     {
          push = false;
          SideTrustEmission.enabled = false;
          audioSource.Stop() ;
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
          

          yield return new WaitForSeconds(1.0f);
          rocketController = Rockt2D.GetComponent<RocketController>();
          SideTrustEmission = GameObject.Find("SideThrustJet").GetComponent<ParticleSystem>().emission;
          Right = true;
     }

}
