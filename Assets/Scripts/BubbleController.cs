using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {

     ParticleSystem.EmissionModule Bubble;
	// Use this for initialization
	void Start () {
          Bubble = GetComponent<ParticleSystem>().emission;
          //Bubble.enabled = true;
          
          var rate = Bubble.rate;
          rate.constantMax = 0.0f;
          Bubble.rate = rate;
       
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void StartBubble()
     {
          var rate = Bubble.rate;
          rate.constantMax = 50.0f;
          Bubble.rate = rate;
     }

     public void StopBubble()
     {
          var rate = Bubble.rate;
          rate.constantMax = 0.0f;
          Bubble.rate = rate;
     }
}
