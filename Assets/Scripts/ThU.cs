using UnityEngine;
using System.Collections;

public class ThU : MonoBehaviour
{

     public GameObject Rockt2D;
     RocketController rocketController;
     private ParticleSystem.EmissionModule SideTrustEmissionL;
     //private GameObject SideThrustJet;
     bool push = false;
     
     public AudioClip audioClip;
     AudioSource audioSource;
     public MainSwitchController mainSwitchController;

     // Use this for initialization
     void Start()
     {
          StartCoroutine("Startdelay");
          audioSource = gameObject.GetComponent<AudioSource>();
          audioSource.clip = audioClip;
     }

     public void PushDown()
     {

          if (rocketController.GetSideThrustForce() < 2.0f)
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
               audioSource.PlayOneShot(audioClip);
          }
     }

     public void PushUp()
     {
          push = false;
          SideTrustEmissionL.enabled = false;
          audioSource.Stop();
     }

     void Update()
     {
          if (push)
          {

               rocketController.UpThruster();

          }
     }

     private IEnumerator Startdelay()
     {
          yield return new WaitForSeconds(1.0f);
          rocketController = Rockt2D.GetComponent<RocketController>();
          SideTrustEmissionL = GameObject.Find("SideThrustJetU").GetComponent<ParticleSystem>().emission;
          
     }

}
