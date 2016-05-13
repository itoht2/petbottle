using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GarageController : MonoBehaviour {
     public SpecData specData;
     public ScoreData scoreData;
     public float TotalScore;
     public Text TotalScoreText;

	// Use this for initialization
	void Start () {
          TotalScore = scoreData.GetTotalScore();
          TotalScoreText.text = "スコア: " + TotalScore +" point";

     }
	
	// Update is called once per frame
	void Update () {
	
	}
}
