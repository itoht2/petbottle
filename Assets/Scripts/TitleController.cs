using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using PlayerPrefs = PreviewLabs.PlayerPrefs;


public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void OnScoreUpdateButtonClicked ()
     {
          StartCoroutine(GoNextScine("ScoreUpdate"));
     }


     public void OnLaunchComplexButtonClicked ()
     {
          StartCoroutine(GoNextScine("LaunchComplex"));
          
     }

     public void OnGarageButtonClicked()
     {
          
          StartCoroutine(GoNextScine("Garage"));

     }

     public void OnScoreButtonClicked()
     {
         
          StartCoroutine(GoNextScine("ScoreAndSpecs"));

     }

     public void OnHomeButtonClicked()
     {
     
          StartCoroutine(GoNextScine("Title"));

     }

     IEnumerator GoNextScine(string NextScine)
     {
          PlayerPrefs.Flush();
          yield return new WaitForSeconds(0.5f);
          
          SceneManager.LoadScene(NextScine);
          yield return null;

     }


}
