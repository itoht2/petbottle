using UnityEngine;
using System.Collections;

public class DialogOpener : MonoBehaviour {
     public Animator _menuAnim;

     // Use this for initialization
     void Start () {
          _menuAnim = gameObject.GetComponent<Animator>();
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void ControlMenuAnimator()
     {
          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));

     }
}
