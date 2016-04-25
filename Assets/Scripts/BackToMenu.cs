using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class BackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void OnBackButtonClicked()
     {
          SceneManager.LoadScene("Title");
     }
}
