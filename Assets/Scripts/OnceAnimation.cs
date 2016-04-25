using UnityEngine;
using System.Collections;

public class OnceAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
          GetComponent<SpriteRenderer>().enabled = true;
          GetComponent<Animator>().SetTrigger("SetOnece");
          GetComponent<Rigidbody2D>().isKinematic =true;
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     void IsKineticOn ()
     {
          GetComponent<Rigidbody2D>().isKinematic =false;
          GetComponent<Animator>().enabled = false;
     }
}
