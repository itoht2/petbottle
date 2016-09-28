using UnityEngine;
using System.Collections;

public class AdControll : MonoBehaviour {

     [SerializeField]
     Animator
        animator;

     // Use this for initialization
     void Start () {

          animator = GameObject.Find("AdDialog").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        

     }

     public void AdDialogUp()
     {
          animator.SetBool("Up", true);

     }

     public void AdDialogDown()
     {
          animator.SetBool("Up", false);

     }
}
