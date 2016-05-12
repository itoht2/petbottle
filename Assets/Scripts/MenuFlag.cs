using UnityEngine;
using System.Collections;

public class MenuFlag : MonoBehaviour {

     public bool OtherMenuOpened;
     public Animator _OpendMenuAnimation;

	// Use this for initialization
	void Start () {
          OtherMenuOpened = false;
          _OpendMenuAnimation = null;

     }

     // Update is called once per frame
     void Update () {
	
	}

     public bool GetOtherMenuOpend()
     {
          return OtherMenuOpened;
     }
}
