﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogOpener : MonoBehaviour {
     public Animator _menuAnim;
     public GameObject detailDialog;
     public NoseCornFolder _noseCornFolder;
     public GameObject Content;
     private Image image;
     private Text itemNameText;
     private int SelectedNumber;


     // Use this for initialization
     void Start() {
          detailDialog = GameObject.Find("DetailDialog");

          Content = this.transform.parent.gameObject;
          if (Content.name == "Content") { 
          _noseCornFolder = Content.GetComponent<ContentsMaker>().GetNoseCornFolder();
          }


          //_noseCornFolder = GameObject.Find("NoseCornFolder").GetComponent<NoseCornFolder>();
          


          _menuAnim = detailDialog.GetComponent<Animator>();
          //_menuAnim.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animations/DetailDialog"));
                            
     }

	
	// Update is called once per frame
	void Update () {
	
	}

     public void ControlMenuAnimator()
     {
          _menuAnim.SetBool("UP", !_menuAnim.GetBool("UP"));

          if ( _menuAnim.GetBool("UP") )
          {
               //image = detailDialog.transform.FindChild("ItemImage").GetComponent<Image>();
               //image.sprite = _noseCornFolder.GetImage(1);

               int.TryParse(this.name.Substring(4, 1), out SelectedNumber);

               itemNameText = detailDialog.transform.FindChild("ItemNameText").GetComponent<Text>();             
               itemNameText.text = _noseCornFolder.GetDiscription(SelectedNumber);

          }

     }
}
