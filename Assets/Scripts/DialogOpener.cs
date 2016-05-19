using UnityEngine;
using System.Collections;

public class DialogOpener : MonoBehaviour {
     public Animator _menuAnim;
     public GameObject detailDialog;

     // Use this for initialization
     void Start () {
          detailDialog = GameObject.Find("DetailDialog");

          //_menuAnim = gameObject.GetComponent<Animator>();
          _menuAnim = detailDialog.GetComponent<Animator>();
          //_menuAnim.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/DetailDialog"));
          
     }

	
	// Update is called once per frame
	void Update () {
	
	}

     public void ControlMenuAnimator()
     {
          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));

     }
}
