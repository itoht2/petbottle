using UnityEngine;
using System.Collections;

public class MenuOpener : MonoBehaviour {
     public Animator _menuAnim;
     public MenuFlag Menuflag;
     private Animator _OtherAnim;

	// Use this for initialization
	void Start () {
          _menuAnim = gameObject.GetComponent<Animator>();
     }
	
	// Update is called once per frame
	void Update () {
	
	}

     public void ControlMenuAnimator()
     {
         //_menuAnim = gameObject.GetComponent<Animator>();

          if (Menuflag.OtherMenuOpened )
          {
               _OtherAnim = Menuflag._OpendMenuAnimation;
               if (_OtherAnim != _menuAnim )
               {
                    _OtherAnim.SetBool("UP", !_OtherAnim.GetBool("UP"));
                    Menuflag.OtherMenuOpened = true;

               } else
               {                    
                    Menuflag.OtherMenuOpened = false;
               }              

          } else
          {
               Menuflag.OtherMenuOpened = true;              
          }

          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));
          Menuflag._OpendMenuAnimation = _menuAnim;
         
     }
}
