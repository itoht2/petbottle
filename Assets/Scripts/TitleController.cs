using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using PlayerPrefs = PreviewLabs.PlayerPrefs;


public class TitleController : MonoBehaviour {
     private SpecData specData;
     public RocketController rocketController;

   

	// Use this for initialization
	void Start () {

          if (GameObject.Find("RocketBody") != null)
          {
               rocketController = GameObject.Find("RocketBody").GetComponent<RocketController>();
          }
         
     }
	
	// Update is called once per frame
	void Update () {

	
	}

     public void OnScoreUpdateButtonClicked ()
     {
          if (rocketController != null)
          {
               rocketController.ScoreDataStore();
          }
     
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

     public IEnumerator GoNextScine(string NextScine)
     {
          specData = GameObject.Find("SpecData").GetComponent<SpecData>();
          specData.SaveData();

        
          yield return new WaitForSeconds(0.5f);
          
          SceneManager.LoadScene(NextScine);
          yield return null;

     }


}
