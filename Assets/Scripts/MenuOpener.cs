using UnityEngine;
using System.Collections;

public class MenuOpener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void ControlMenuAnimator()
     {
          Animator _menuAnim = gameObject.GetComponent<Animator>();
          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));
     }
}
