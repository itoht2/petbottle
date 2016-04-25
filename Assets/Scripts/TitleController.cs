using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void OnLaunchComplexButtonClicked ()
     {
          SceneManager.LoadScene("LaunchComplex");
     }

     public void OnGarageButtonClicked()
     {
          SceneManager.LoadScene("Garage");

     }

     public void OnScoreButtonClicked()
     {
          SceneManager.LoadScene("ScoreAndSpecs");

     }

     public void OnHomeButtonClicked()
     {
          SceneManager.LoadScene("Title");
     }
}
