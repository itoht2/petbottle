using UnityEngine;
using System.Collections;

public class AccordionExpander : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void OnClick()
     {
          var anim = GetComponent<Animator>();
          anim.SetBool("Open", !anim.GetBool("Open"));
     }
}
